/****************************************************************************
* File Name: moneyBagBombShoot.cs
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
    [SerializeField] protected int amount;
    [SerializeField] protected int dmg;
    [SerializeField] protected float elapsedTime;
    [SerializeField] protected float delay;
    [SerializeField] protected float imgRotation;
    [SerializeField] protected GameObject bomb;
    [SerializeField] protected GameObject gameManager;

    // Update is called once per frame
    void Update()
    {
        // Checks if your left clicking and delays shooting by the delay
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
        // lowers until 0
        if (elapsedTime >= 0)
        {
            elapsedTime -= Time.deltaTime;
        }
    }
}
