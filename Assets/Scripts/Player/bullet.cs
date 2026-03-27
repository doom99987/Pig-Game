using UnityEngine;
using UnityEngine.Rendering;

public class bullet : MonoBehaviour
{
    protected int bulletPierce;
    protected GameObject gameManager;

    [Header("Animator")]
    [SerializeField] protected Animator animator;

    [Header("RigidBody")]
    [Tooltip("Rigidbody of the object")]
    [SerializeField] protected Rigidbody2D rb;

    [Header("Bullet Variables")]
    [SerializeField] protected float bulletSpeed = 5f;
    [SerializeField] protected float bulletDmg = 1f;
    [SerializeField] protected float bulletTime = 1f;
    Vector3 dir;

    protected float bulletCurSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("gameManager");
        bulletPierce = gameManager.GetComponent<shopManager>().getPierceCount();
        animator.SetInteger("coinState", gameManager.GetComponent<shopManager>().getBulletUpgradeCount());

        // Gets a vector in the direction the bullet travels and adds force to the bullet
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        dir = (mousePos - gameObject.transform.position);
        rb.AddForce(dir.normalized * bulletSpeed * 100f);
    }

    // Update is called once per frame
    void Update()
    {
            if(gameManager.GetComponent<gameManager>().getGameState())
            {
                rb.linearVelocity = Vector2.zero;
        }
            if (bulletTime <= 0f)
            {
                Destroy(gameObject);
            }
            else if(gameManager.GetComponent<gameManager>().getGameState() == false)
        {
                bulletTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Ranged") || collision.gameObject.CompareTag("Melee"))
    {
        collision.gameObject.GetComponent<enemyHp>().takeDmg(gameManager.GetComponent<shopManager>().getBulletUpgradeCount() + 1);
        if (bulletPierce <= 0 || collision.gameObject.GetComponent<enemyHp>().getEnemyHp() > 0)
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
