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
    protected GameObject player;
    protected float timer;
    protected float enemyDistanceFromPlayer;
    protected GameObject gameManager;

    [Header("Animator")]
    [SerializeField] Animator animator;

    [Header("Enemy Movement")]
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

    private direction enemyDir;
    private enum direction
    {
        left, right, up, down
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("gameManager");
        gameManager.GetComponent<roundManager>().getObjects(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 dir = (transform.position - player.transform.position).normalized;

        if (Vector2.Distance(dir, Vector2.left) < Vector2.Distance(dir, Vector2.up) && Vector2.Distance(dir, Vector2.down) > Vector2.Distance(dir, Vector2.left))
        {
            enemyDir = direction.right;
        }
        else if (Vector2.Distance(dir, Vector2.right) < Vector2.Distance(dir, Vector2.down) && Vector2.Distance(dir, Vector2.up) > Vector2.Distance(dir, Vector2.right))
        {
            enemyDir = direction.left;
        }
        else if (dir.y > 0)
        {
            enemyDir = direction.down;
        }
        else if (Vector2.Distance(dir, Vector2.down) < Vector2.Distance(dir, Vector2.right) && Vector2.Distance(dir, Vector2.left) > Vector2.Distance(dir, Vector2.down))
        {
            enemyDir = direction.up;
        }
        else
        {
            enemyDir = direction.down;
        }

        animator.SetInteger("enemyDirection", (int) enemyDir);
    }

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
    /// <param name="collision"></param>
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

    /// <summary>
    /// Gives the current speed of the Enemy
    /// </summary>
    /// <returns></returns>
    public float getCurrentSpeed()
    {
        return curSpeed;
    }
}
