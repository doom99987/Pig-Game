/****************************************************************************
* File Name: enemyAi.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: Dictates how the enemy moves depending on its type
*
****************************************************************************/

using UnityEngine;

public class enemyAI : MonoBehaviour
{
    protected GameObject player;
    protected float timer;
    protected float enemyDistanceFromPlayer;
    protected GameObject gameManager;

    [Header("Player Movement")]
    [Tooltip("Variable to control the current speed of the Enemy")]
    [SerializeField] protected float curSpeed = 25f;
    [Tooltip("A multiplier of how strong the enemy gets pushed back after hitting a player")]
    [SerializeField] protected float pushBackMult = 100;
    [Tooltip("The distance an enemy stops from the player")]
    [SerializeField] protected float rangedEnemyStopDis = 7;
    [Tooltip("How close the player has to be for the enemy to run away")]
    [SerializeField] protected float rangedEnemyBackOffDis = 3;
    [Tooltip("Enemy rigid body")]
    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("gameManager");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameManager.GetComponent<gameManager>().getGameState())
        {
            enemyDistanceFromPlayer = Vector2.Distance(player.transform.position, gameObject.transform.position);
            Vector2 movement = (player.transform.position - gameObject.transform.position).normalized;

            if (gameObject.CompareTag("Melee"))
            {
                rb.AddForce(movement * curSpeed);
            }
            if (gameObject.CompareTag("Ranged") && Mathf.Abs(enemyDistanceFromPlayer) > rangedEnemyStopDis)
            {
                rb.AddForce(movement * curSpeed);
            }
            if (gameObject.CompareTag("Ranged") && Mathf.Abs(enemyDistanceFromPlayer) < rangedEnemyBackOffDis)
            {
                rb.AddForce(movement * -curSpeed);
            }
        }
    }
    /// <summary>
    /// Lowers the players life and pushes the enemy back when enemy collides w/ player
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !gameManager.GetComponent<gameManager>().getGameState())
        {
            // Takes 1 Dmg
            gameManager.GetComponent<HpManager>().takeDmg();

            // Pushes player back
            Vector2 movement = (player.transform.position - gameObject.transform.position).normalized;
            rb.AddForce(movement * -(curSpeed * pushBackMult));
        }
    }

    /// <summary>
    /// Gives the current speed of the Enemy
    /// </summary>
    /// <returns></returns>
    public float getCurrentSpeed()
    {
        return curSpeed;
    }
}
