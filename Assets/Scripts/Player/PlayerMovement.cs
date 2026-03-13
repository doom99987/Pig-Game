/****************************************************************************
* File Name: PlayerMovement.c
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script allows the payer to move using wasd.
*
****************************************************************************/
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] protected float curSpeed = 25f; //variable to control the current speed of the player
    [SerializeField] protected float maxSpeed = 35f; //variable to control the max speed of the player
    [SerializeField] Rigidbody2D rb; //Player rigid body
    /// <summary>
    /// if player is moving, add force to the player rigid body in the direction of the movement
    /// </summary>
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        rb.AddForce(movement * curSpeed);

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

