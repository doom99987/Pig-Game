using UnityEngine;

public class bullet : MonoBehaviour
{
    
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
        // Gets a vector in the direction the bullet travels
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 dir = (mousePos - gameObject.transform.position);
        rb.AddForce(dir * bulletSpeed);
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
        if (collision.gameObject.CompareTag("Ranged") || collision.gameObject.CompareTag("Melee"))
        {
            collision.gameObject.GetComponent<enemyHp>().takeDmg();
            Destroy(gameObject);
        }
    }
}
