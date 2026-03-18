using UnityEngine;

public class enemyAI : MonoBehaviour
{
    protected GameObject player;
    protected float timer;
    protected float enemyDistanceFromPlayer;
    protected GameObject gameManager;

    [Header("Player Movement")]
    [SerializeField] protected float curSpeed = 25f; //variable to control the current speed of the Enemy
    [SerializeField] protected float pushBackMult = 100;
    [SerializeField] protected float rangedEnemyStopDis;
    [SerializeField] protected float rangedEnemyBackOffDis;
    [SerializeField] Rigidbody2D rb; //Enemy rigid body

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
    public float getCurrentSpeed()
    {
        return curSpeed;
    }
}
