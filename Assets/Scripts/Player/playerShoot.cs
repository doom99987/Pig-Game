/****************************************************************************
* File Name: playerShoot.cs
* Author: Caleb Bohm
* DigiPen Email: caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: Spawns in the bullet facing the mouse
*
****************************************************************************/

using UnityEngine;
public class playerShoot : MonoBehaviour
{
    protected float elapsedTime;
    [Header("Shoot Animation Direction")]
    [Tooltip("Controls the spot which the bullet spawns according to the direction the player is facing")]
    [SerializeField] GameObject[] spawnPoints;

    [Header("Projectile")] 
    [SerializeField] GameObject bullet;

    [Header("Refrences")]
    [SerializeField] GameObject gameManager;

    [Header("Bullet Variables")]
    [Tooltip("Amount of money removed when shooting (1 = $0.01)")]
    [SerializeField] int[] removeAmount = {1, 3 ,5};
    [Tooltip("Manages the angle the object is spawned in at")]
    [SerializeField] protected float imgRotation = 90f;
    [Tooltip("Delay between bullets fired")]
    [SerializeField] protected float delay = 1f;

    protected int playerDir = 0;
    // Update is called once per frame
    void Update()
    {
        // lowers until 0
        if (elapsedTime >= 0)
        {
            elapsedTime -= Time.deltaTime;
        }
        // Gets the facing direction of the player
        playerDir = gameObject.GetComponent<playerMovement>().getPlayerDir();

        int bulletUpgradeCount = gameManager.GetComponent<shopManager>().getBulletUpgradeCount();

        // Checks if your left clicking and delays shooting by the delay
        if (Input.GetMouseButton(0) && elapsedTime <= 0 && 
            gameManager.GetComponent<moneyManager>().getMoney() > (gameManager.GetComponent<shopManager>().getBulletUpgradeCount() +
            removeAmount[bulletUpgradeCount]) && !gameManager.GetComponent<gameManager>().getGameState())
        {
            // Gets the angle towards the mouse
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 dir = (mousePos - gameObject.transform.position);
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + imgRotation;

            // Spawns an object pointing towards the mouse
            Instantiate(bullet, spawnPoints[playerDir].transform.position, Quaternion.Euler(0, 0, angle));
            gameManager.GetComponent<moneyManager>().removeMoney(gameManager.GetComponent<shopManager>().getBulletUpgradeCount() + removeAmount[bulletUpgradeCount]);
            elapsedTime = delay;
        }
    }

}
