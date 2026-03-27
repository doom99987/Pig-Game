/****************************************************************************
* File Name: PlayerMovement.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script allows the payer to move using wasd.
*
****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [Header("Game Manager")]
    [SerializeField] protected GameObject gameManager;

    [Header("Animator")]
    [SerializeField] Animator animator;

    [Header("Player Movement")]
    //variable to control the current speed of the player
    [SerializeField] protected float curSpeed = 25f;
    //variable to control the max speed of the player
    [SerializeField] protected float maxSpeed = 35f; 
    [SerializeField] Rigidbody2D rb;

    private direction playerDir;
    private enum direction
    {
        left, right, up, down
    }

    private void Update()
    {
        // Grabs the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        // checks if the mouse is facing which direction relative to the player
        if (transform.position.x > mousePos.x && Mathf.Abs(mousePos.x) > Mathf.Abs(mousePos.y))
        {
            playerDir = direction.left;
        }
        else if (transform.position.x < mousePos.x && Mathf.Abs(mousePos.x) > Mathf.Abs(mousePos.y))
        {
            playerDir = direction.right;
        }
        else if (transform.position.y > mousePos.y && Mathf.Abs(mousePos.y) > Mathf.Abs(mousePos.x))
        {
            playerDir = direction.down;
        }
        else
        {
            playerDir = direction.up;
        }

        animator.SetInteger("playerDirection", (int) playerDir);
    }

    /// <summary>
    /// if player is moving, add force to the player rigid body in the direction of the movement
    /// </summary>
    private void FixedUpdate()
    {
        if (!gameManager.GetComponent<gameManager>().getGameState())
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontal, vertical);
            rb.linearVelocity = movement * curSpeed;
        }
    }

    public float getCurrentSpeed()
    {
        return curSpeed;
    }

    public void setCurSpeed(float speed)
    {
        if(getCurrentSpeed() <=  maxSpeed)
        {
            curSpeed = speed;
        }
    }

}

