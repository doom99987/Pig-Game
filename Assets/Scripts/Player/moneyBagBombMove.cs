/****************************************************************************
* File Name: moneyBagBombMove.cs
* Author: Caleb Bohm
* DigiPen Email: caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: Makes the bombs move and explode
*
****************************************************************************/

using UnityEngine;

public class moneyBagBombMove : MonoBehaviour
{
    protected int bulletPierce;
    protected GameObject gameManager;
    protected bool explode = false;

    [Header("RigidBody")]
    [Tooltip("Rigidbody of the object")]
    [SerializeField] protected Rigidbody2D rb;

    [Header("Variables")]
    [SerializeField] protected float explosionSize = 1;
    [SerializeField] protected float speed = 1.95f;
    [SerializeField] protected float dmg = 1f;
    [SerializeField] protected float lifeTime = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("gameManager");
        bulletPierce = gameManager.GetComponent<shopManager>().getPierceCount();

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
        void ExplosionDamage(Vector2 center, float radius)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
            foreach (var hitCollider in hitColliders)
            {
            if (hitCollider.gameObject.CompareTag("Ranged") || hitCollider.gameObject.CompareTag("Melee"))
                {
                    hitCollider.gameObject.GetComponent<enemyHp>().takeDmg(gameManager.GetComponent<shopManager>().getBulletUpgradeCount() + 1);
                }
            }
            Destroy(gameObject);
        }

    // Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this.
    void OnDrawGizmos()
    {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionSize);
        // Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
    }
}

