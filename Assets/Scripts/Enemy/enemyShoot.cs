/****************************************************************************
* File Name: enemyShoot.cs
* Author: Caleb Bohm
* DigiPen Email: caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: Spawns in the bullet facing the mouse
*
****************************************************************************/

using System.Collections;
using UnityEngine;
public class enemyShoot : MonoBehaviour
{

    [Header("Projectile")]
    [SerializeField] GameObject bullet;

    [Header("Rigidbody2D")]
    [SerializeField] Rigidbody2D rb;

    [Header("Bullet Variables")]
    [Tooltip("Manages the angle the object is spawned in at")]
        [SerializeField] private float imgRotation = 90f;
    [Tooltip("Delay between bullets fired")]
        [SerializeField] private float delay = 1f;

    [Header("animation")]
    [SerializeField] float shootAnimDelay = 0.1f;
    [SerializeField] GameObject shootLocation;

    private float elapsedTime;
    private GameObject player;
    private GameObject gameManager;
    private Animator animator;
    private bool shooting = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("gameManager");
        animator = gameObject.GetComponent<Animator>();
        elapsedTime = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetComponent<gameManager>().getGameState())
        {

            // Checks if your left clicking and delays shooting by the delay
            if (elapsedTime <= 0 && rb.linearVelocity.magnitude <= 1f && !shooting)
            {
                StartCoroutine(shoot());
            }
            // lowers until 0
            if (elapsedTime >= 0)
            {
                elapsedTime -= Time.deltaTime;
            }
        }
    }

    private IEnumerator shoot()
    {
        // Pauses the shooting delay for the animation
        shooting = true;
        // Plays the animation attack
        animator.SetTrigger("attack");
        yield return new WaitForSeconds(shootAnimDelay);
        // Gets the angle towards the player from the enemy
        Vector3 dir = (player.transform.position - gameObject.transform.position);
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + imgRotation;

        // Spawns an object pointing towards the mouse
        Instantiate(bullet, shootLocation.transform.position, Quaternion.Euler(0, 0, angle));
        // Resets the delay
        elapsedTime = delay - shootAnimDelay;
        // Renables the shooting delay
        shooting = false;
    }

}
