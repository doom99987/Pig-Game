/****************************************************************************
* Name: moneyBagBombMove.cs
* Author: Caleb Bohm
* DigiPen Email: caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: Makes the bombs move and explode
*
****************************************************************************/
using System.Collections;
using UnityEngine;

public class moneyBagBombMove : MonoBehaviour
{

    [Header("RigidBody")]
    [Tooltip("Rigidbody of the object")]
        [SerializeField] private Rigidbody2D rb;

    [Header("Animator")]
    private Animator animator;

    [Header("Bomb Variables")]
    [Tooltip("Size of the bombs explosion")]
        [SerializeField] private float explosionSize = 1;
    [Tooltip("speed at which the bomb moves (DO NOT TOUCH PLEASE If you want to change the speed talk to programmers)")]
        [SerializeField] private float speed = 1.95f;
    [Tooltip("How long the bomb will last before exploding (DO NOT TOUCH PLEASE If you want to change the speed talk to programmers)")]
        [SerializeField] private float lifeTime = 1f;
    [Tooltip("Delays destroying the bomb object by a set amount of time")]
        [SerializeField] private float delayDestruction = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        // Gets a vector in the direction the bullet travels and adds force to the bullet
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 dir = (mousePos - gameObject.transform.position);
        rb.linearVelocity = dir * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime <= 0f)
        {
            ExplosionDamage(transform.position, explosionSize);
        }
        else
        {
            lifeTime -= Time.deltaTime;
        }
    }
    /// <summary>
    /// Destroys all the enemies within the bombs radius.
    /// </summary>
    /// <param name="center">Center of the explosion</param>
    /// <param name="radius">Size of the explosion</param>
    void ExplosionDamage(Vector2 center, float radius)
    {
        // Gets all the gameObjects collideres within range
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
        // Loop over all colliders
        foreach (var hitCollider in hitColliders)
        {
            // if its an enemy's collider
            if (hitCollider.gameObject.CompareTag("Ranged") || hitCollider.gameObject.CompareTag("Melee"))
                {
                    // The enemy takes damage equal to 99999
                    hitCollider.gameObject.GetComponent<enemyHp>().takeDmg(99999);
                }
            }
        StartCoroutine(bombBoom());
    }

    private IEnumerator bombBoom()
    {
        animator.SetTrigger("Explode");
        yield return new WaitForSeconds(delayDestruction);
        Destroy(gameObject);
    }

    // Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this.
    void OnDrawGizmos()
    {
        // Draws the bom explosion radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionSize);
    }
}

