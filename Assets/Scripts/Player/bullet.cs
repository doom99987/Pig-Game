/****************************************************************************
* Name: bullet.cs
* Author: David Konvisser & Caleb Bohm
* DigiPen Email: david.konvisser@digipen.edu & caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: sets the bullet velocity, damage, and lifetime.
*
****************************************************************************/

using UnityEngine;

public class bullet : MonoBehaviour
{
    private int bulletPierce;
    private GameObject gameManager;
    private bool fixVelocity = false;
    private Vector3 dir;

    [Header("Animator")]
    [SerializeField] private Animator animator;

    [Header("RigidBody")]
    [Tooltip("Rigidbody of the object")]
        [SerializeField] private Rigidbody2D rb;

    [Header("Bullet")]
    [Tooltip("Speed of the bullet")]
        [SerializeField] private float speed = 5f;
    [Tooltip("Time until the bullet is destroyed")]
        [SerializeField] private float time = 1f;
    [Tooltip("Rotation speed of the bullet")]
        [SerializeField] private float rotSpeed = 5f;

    protected float bulletCurSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Grabs gameManager
        gameManager = FindFirstObjectByType<shopManager>().gameObject;
        // Gets the total pierce level
        bulletPierce = gameManager.GetComponent<shopManager>().getPierceCount();
        // Sets the animation of the bullet
        animator.SetInteger("coinState", gameManager.GetComponent<shopManager>().getBulletUpgradeCount());
        // Sets the object into a list to be cleared when round ends
        gameManager.GetComponent<roundManager>().getObjects(gameObject);

        // Gets a vector in the direction the bullet travels
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        dir = (mousePos - gameObject.transform.position);
        // Gives the bullet speed in the direction of dir
        rb.AddForce(dir.normalized * speed * 100f);
        rb.AddTorque(rotSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Pauses the bullet
        if(gameManager.GetComponent<gameManager>().getGameState())
        {
            rb.linearVelocity = Vector2.zero;
            fixVelocity = true;
        }
        // Unpauses the bullet
        else if (fixVelocity)
        {
            rb.AddForce(dir.normalized * speed * 100f);
            fixVelocity = false;
        }
        if (!gameManager.GetComponent<gameManager>().getGameState())
        {
            // Lifetime of the bullet
            if (time <= 0f)
            {
                Destroy(gameObject);
            }
            else if(gameManager.GetComponent<gameManager>().getGameState() == false)
            {
                time -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the bullet hits a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        // Checks if the bullet collided with an enemy
        if (collision.gameObject.CompareTag("Ranged") || collision.gameObject.CompareTag("Melee"))
        {
            // Deals damage to enemy
            collision.gameObject.GetComponent<enemyHp>().takeDmg(gameManager.GetComponent<shopManager>().getBulletUpgradeCount() + 1);
            // Checks if the bullet would not pierce the enemy
            if (bulletPierce <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                bulletPierce--;
            }
        }
    }
}
