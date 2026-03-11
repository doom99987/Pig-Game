using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] int speed = 1;
    [SerializeField] Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
     
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        rb.AddForce(movement * speed);
    }
}

