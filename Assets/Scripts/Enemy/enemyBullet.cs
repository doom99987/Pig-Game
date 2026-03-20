using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    protected int bulletPierce;
    protected GameObject gameManager;
    protected GameObject player;

    [Header("Animator")]
    [SerializeField] protected Animator animator;

    [Header("RigidBody")]
    [Tooltip("Rigidbody of the object")]
    [SerializeField] protected Rigidbody2D rb;

    [Header("Bullet Variables")]
    [SerializeField] protected float bulletSpeed = 5f;
    [SerializeField] protected float bulletDmg = 1f;
    [SerializeField] protected float bulletTime = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("gameManager");
        player = GameObject.Find("Player");
        bulletPierce = gameManager.GetComponent<shopManager>().getPierceCount();
        animator.SetInteger("coinState", gameManager.GetComponent<shopManager>().getBulletUpgradeCount());

        // Gets a vector in the direction the bullet travels and adds force to the bullet
        Vector3 dir = (player.transform.position - gameObject.transform.position);
        rb.AddForce(dir.normalized * bulletSpeed * 100f);
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletTime <= 0f)
        {
            Destroy(gameObject);
        }
        else
        {
            bulletTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.GetComponent<hpManager>().takeDmg();
            Destroy(gameObject);
        }
    }
}
