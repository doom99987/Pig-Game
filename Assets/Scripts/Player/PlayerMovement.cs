/****************************************************************************
* File Name: bullet.cs
* Author: David Konvisser & Caleb Bohm
* DigiPen Email: david.konvisser@digipen.edu & caleb.bohm@digipen.edu
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

        Vector2 dir = (transform.position - mousePos).normalized;

        

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

    /// <summary>
    /// getter for the current speed of the player
    /// </summary>
    /// <returns></returns>
    public float getCurrentSpeed()
    {
        return curSpeed;
    }

    /// <summary>
    /// setter for the current speed of the player
    /// </summary>
    /// <param name="speed"></param>
    public void setCurSpeed(float speed)
    {
        if(getCurrentSpeed() <=  maxSpeed)
        {
            curSpeed = speed;
        }
    }

}

