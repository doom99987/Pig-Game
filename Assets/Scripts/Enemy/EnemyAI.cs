using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    protected float timer;

    [Header("GameObjects")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameManager;
    
    [Header("Player Movement")]
    [SerializeField] protected float curSpeed = 25f; //variable to control the current speed of the Enemy
    [SerializeField] Rigidbody2D rb; //Enemy rigid body

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameManager.GetComponent<gameManager>().getGameState())
        {
            Vector2 movement = (player.transform.position - gameObject.transform.position).normalized;
            rb.AddForce(movement * curSpeed);
        }
    }
    public float getCurrentSpeed()
    {
        return curSpeed;
    }
}
