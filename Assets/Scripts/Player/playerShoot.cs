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

    [Header("Projectile")] 
    [SerializeField] GameObject bullet;

    [Header("Bullet Variables")]
    [Tooltip("Manages the angle the object is spawned in at")]
    [SerializeField] protected float imgRotation = 90;
    [Tooltip("Delay between bullets fired")]
    [SerializeField] protected float delay = 1f;
    // Update is called once per frame
    void Update()
    {
        // Checks if your left clicking and delays shooting by the delay
        if (Input.GetMouseButton(0) && elapsedTime <= 0)
        {
            // Gets the angle towards the mouse
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 dir = (mousePos - gameObject.transform.position);
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
