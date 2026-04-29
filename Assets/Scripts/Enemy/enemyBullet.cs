/****************************************************************************
* Name: enemyBullet.cs
* Author: David Konvisser & Caleb Bohm
* DigiPen Email: david.konvisser@digipen.edu & caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: Sets the enemy bullet velocity, damage, and lifetime.
*
****************************************************************************/

using UnityEngine;

public class enemyBullet : MonoBehaviour
{

    [Header("RigidBody")]
    [Tooltip("Rigidbody of the object")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Bullet Variables")]
    [Tooltip("Speed of the bullet")]
    [SerializeField] private float speed = 5f;
    [Tooltip("Lifetime of the bullet")]
    [SerializeField] private float time = 1f;
    [Tooltip("Rotation speed of the bullet")]
    [SerializeField] private float rotSpeed = 5f;

    private GameObject gameManager;
    private GameObject player;
    private bool fixVelocity = false;
    private Vector3 dir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("gameManager");
        player = GameObject.Find("Player");
        // Sets the object into a list to be cleared when round ends
        gameManager.GetComponent<roundManager>().getObjects(gameObject);

        // Gets a vector in the direction the bullet travels
        dir = player.transform.position - gameObject.transform.position;

        rb.AddForce(dir.normalized * speed * 100f);
        rb.AddTorque(rotSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        // Pauses the bullet
        if (gameManager.GetComponent<gameManager>().getGameState())
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
            else if (gameManager.GetComponent<gameManager>().getGameState() == false)
            {
                time -= Time.deltaTime;
            }
        }
    }

    /// <summary>
    ///  Deal damage to the player
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        // Check if collided with player
        if (collision.gameObject.CompareTag("Player") && !gameManager.GetComponent<gameManager>().getGameState())
        {
            // Player Takes dmg and destroy the bullet
            gameManager.GetComponent<hpManager>().takeDmg();
            Destroy(gameObject);
        }
    }
}
