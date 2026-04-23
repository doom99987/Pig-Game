/****************************************************************************
* File Name: moenyShopUpgradeLevel.cs
* Author: Caleb Bohm
* DigiPen Email: caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: Shows which upgrade is next in the list
*
****************************************************************************/

using UnityEngine;

public class moneyShopUpgradeLevel : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator animator;

    private GameObject gameManager;

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("gameManager");
        // Sets the current animation state in the shop
        animator.SetInteger("coinState", gameManager.GetComponent<shopManager>().getBulletUpgradeCount() + 1);
    }
}
