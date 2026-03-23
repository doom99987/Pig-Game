/****************************************************************************
* File Name: PlayerMovement.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script allows the payer to move using wasd.
*
****************************************************************************/
using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("Game Manager")]
    [SerializeField] protected GameObject gameManager;

    [Header("Player Movement")]
    //variable to control the current speed of the player
    [SerializeField] protected float curSpeed = 25f;
    //variable to control the max speed of the player
    [SerializeField] protected float maxSpeed = 35f; 
    [SerializeField] Rigidbody2D rb; 
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

