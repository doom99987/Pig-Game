/****************************************************************************
* Name: moneyBagBombShoot.cs
* Author: Caleb Bohm
* DigiPen Email: caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: Allows the player to shoot the bombs
*
****************************************************************************/

using UnityEngine;

public class moneyBagBombShoot : MonoBehaviour
{
    [Header("Observable Variables (Dont Touch)")]
    [Tooltip("How many bombs the player has")]
        [SerializeField] protected int amount;
    [Tooltip("Less than 0 means you can throw a bomb otherwise you cant")]
        [SerializeField] protected float elapsedTime;

    [Header("Bomb Settings")]
    [Tooltip("How much damage the bombs do")]
        [SerializeField] protected int dmg;
    [Tooltip("The delay between bomb throws")]
        [SerializeField] protected float delay;
    [Tooltip("The rotation of the bomb")]
        [SerializeField] protected float imgRotation;

    [Header("Necessities")]
    [Tooltip("Bomb Object")]
        [SerializeField] protected GameObject bomb;
    [Tooltip("Game Manager")]
        [SerializeField] protected GameObject gameManager;

    // Update is called once per frame
    void Update()
    {
        // Checks if your left clicking and delays shooting by the delayed amount
        if (Input.GetMouseButtonDown(1) && elapsedTime <= 0 && gameManager.GetComponent<shopManager>().getBombCount() > 0)
        {
            // Gets the angle towards the mouse
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 dir = (mousePos - gameObject.transform.position);
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + imgRotation;

            // Spawns an object pointing towards the mouse
            Instantiate(bomb, gameObject.transform.position, Quaternion.Euler(0, 0, angle));
            elapsedTime = delay;
            gameManager.GetComponent<shopManager>().subtractBombCount(1);
        }
        // Timer
        if (elapsedTime >= 0)
        {
            elapsedTime -= Time.deltaTime;
        }
    }
}
