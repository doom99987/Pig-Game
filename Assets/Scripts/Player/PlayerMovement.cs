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

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float speed = 25f; //variable to control the speed of the player
    [SerializeField] Rigidbody2D rb; //Player rigid body
    /// <summary>
    /// if player is moving, add force to the player rigid body in the direction of the movement
    /// </summary>
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        rb.AddForce(movement * speed);
    }
}

