/****************************************************************************
* File Name: gameManager.cs
* Author: Caleb Bohm
* DigiPen Email: caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: Dictates How the enemy moves depending on its type
*
****************************************************************************/

using UnityEngine;

public class enemyAI : MonoBehaviour
{
    private GameObject player;
    private float enemyDistanceFromPlayer;
    private GameObject gameManager;
    private Vector2 movement;

    [Header("Animator")]
    [SerializeField] Animator animator;

    [Header("Enemy Movement")]
    [Tooltip("Variable to control the current speed of the Enemy")]
    [SerializeField] private float curSpeed = 25f;
    [Tooltip("A multiplier of how strong the enemy gets pushed back after hitting a player")]
    [SerializeField] private float pushBackMult = 100;
    [Tooltip("The distance an enemy stops from the player")]
    [SerializeField] private float rangedEnemyStopDis = 7;
    [Tooltip("How close the player has to be for the enemy to run away")]
    [SerializeField] private float rangedEnemyBackOffDis = 3;
    [Tooltip("Enemy rigid body")]
    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("gameManager");
        gameManager.GetComponent<roundManager>().getObjects(gameObject);
        movement = (player.transform.position - gameObject.transform.position).normalized;
    }

    // Update is called once per frame
    private void Update()
    {
        animator.SetFloat("Xdirection", movement.x);
        animator.SetFloat("Ydirection", movement.y);
    }

    void FixedUpdate()
    {
        if (!gameManager.GetComponent<gameManager>().getGameState())
        {
            enemyDistanceFromPlayer = Vector2.Distance(player.transform.position, gameObject.transform.position);
            movement = (player.transform.position - gameObject.transform.position).normalized;

            // Melee movement
            if (gameObject.CompareTag("Melee"))
            {
                rb.AddForce(movement * curSpeed);
            }
            // Ranged movement
            else if (gameObject.CompareTag("Ranged") && Mathf.Abs(enemyDistanceFromPlayer) > rangedEnemyStopDis)
            {
                rb.AddForce(movement * curSpeed);
            }
            else if (gameObject.CompareTag("Ranged") && Mathf.Abs(enemyDistanceFromPlayer) < rangedEnemyBackOffDis)
            {
                rb.AddForce(movement * -curSpeed);
            }
        }
    }

    /// <summary>
    /// Lowers the players life and pushes the enemy back when enemy collides w/ player
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !gameManager.GetComponent<gameManager>().getGameState())
        {
            // Takes 1 Dmg
            gameManager.GetComponent<hpManager>().takeDmg();

            // Pushes player back
            Vector2 movement = (player.transform.position - gameObject.transform.position).normalized;
            rb.AddForce(movement * -(curSpeed * pushBackMult));
        }
    }
}
