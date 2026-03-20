/****************************************************************************
* File Name: enemyShoot.cs
* Author: Caleb Bohm
* DigiPen Email: caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: Spawns in the bullet facing the mouse
*
****************************************************************************/

using UnityEngine;
public class enemyShoot : MonoBehaviour
{
    protected float elapsedTime;
    protected GameObject player;
    protected GameObject gameManager;

    [Header("Projectile")] 
    [SerializeField] GameObject bullet;

    [Header("Rigidbody2D")]
    [SerializeField] Rigidbody2D rb;

    [Header("Bullet Variables")]
    [Tooltip("Manages the angle the object is spawned in at")]
    [SerializeField] protected float imgRotation = 90f;
    [Tooltip("Delay between bullets fired")]
    [SerializeField] protected float delay = 1f;

    private void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("gameManager");
        elapsedTime = delay;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if your left clicking and delays shooting by the delay
        if (elapsedTime <= 0 && !gameManager.GetComponent<gameManager>().getGameState() && rb.linearVelocity.magnitude <= 1f)
        {
            // Gets the angle towards the player from the enemy
            Vector3 dir = (player.transform.position - gameObject.transform.position);
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + imgRotation;

            // Spawns an object pointing towards the mouse
            Instantiate(bullet, gameObject.transform.position, Quaternion.Euler(0, 0, angle));
            elapsedTime = delay;
        }
        // lowers until 0
        if (elapsedTime >= 0)
        {
            elapsedTime -= Time.deltaTime;
        }
    }

}
