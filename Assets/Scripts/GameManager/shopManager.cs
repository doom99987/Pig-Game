/****************************************************************************
* File Name: shopManager.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script manages the shop, including the functions to buy upgrades for the player, such as speed, max HP, and healing. 
* It also keeps track of the counts for each upgrade to determine the cost of the next upgrade.
*
****************************************************************************/
using System;
using TMPro;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    // all the counts for the upgrades, used to determine the cost of the next upgrade.
    protected int sCount = 0;
    protected int hCount = 0;
    protected int healingCount = 0;
    protected int pierceCount = 0;

    [Header("Upgrade Limits")]
    [Tooltip("The maximum number of times the player can upgrade their speed.")]
    [SerializeField] protected int sCountMax =10;
    [Tooltip("The maximum number of times the player can upgrade their hp.")]
    [SerializeField] protected int hCountMax = 10;
    [Tooltip("The maximum number of times the player can heal.")]
    [SerializeField] protected int healingCountMax = 10;
    //[SerializeField] protected int pierceCountMax = 10;

    [Header("References")]
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI buySpeedText;

    [Header("Upgrade Costs")]
    [SerializeField] float[] speedCost = { 5, 50, 500, 5000, 50000, 500000 };
    [SerializeField] float[] hpCost = { 5, 50, 500, 5000, 50000, 500000 };
    [SerializeField] float[] healingCost = { 5, 50, 500, 5000, 50000, 500000 };
    //[SerializeField] float[] pierceCost = { 5, 50, 500, 5000 };
    public void buySpeed()
    {
        if (gameManager.GetComponent<moneyManager>().getMoney() >= speedCost[sCount] && sCount < sCountMax)
                {
            //upgrades the player's speed by 1.
            player.GetComponent<playerMovement>().setCurSpeed(player.GetComponent<playerMovement>().getCurrentSpeed() + 1); 
            gameManager.GetComponent<moneyManager>().removeMoney(speedCost[sCount]);
            buySpeedText.text = $"Buy ${speedCost[sCount + 1] / 100f}";
            sCount++;
        }
    }
    public void buyHp()
    {
        if (gameManager.GetComponent<moneyManager>().getMoney() >= hpCost[hCount] && hCount < hCountMax)
        {
            gameManager.GetComponent<HpManager>().upgradeMaxHp();
            gameManager.GetComponent<moneyManager>().removeMoney(hpCost[hCount]);
            buySpeedText.text = $"Buy ${hpCost[hCount + 1] / 100f}";
            hCount++;
        }
    }
    public void buyHealing()
    {
        if (gameManager.GetComponent<moneyManager>().getMoney() >= healingCost[healingCount] && healingCount < healingCountMax)
        {
            gameManager.GetComponent<HpManager>().heal();
            gameManager.GetComponent<moneyManager>().removeMoney(healingCost[healingCount]);
            buySpeedText.text = $"Buy ${healingCost[healingCount + 1] / 100f}";
            healingCount++;
        }
    }
    //public void buyPierce()
    //{
    //    if (gameManager.GetComponent<moneyManager>().getMoney() >= pierceCost[pierceCount])
    //    {
    //        //player.GetComponent<PlayerMovement>().setCurSpeed(player.GetComponent<PlayerMovement>().getCurrentSpeed() + 1);
    //        gameManager.GetComponent<moneyManager>().removeMoney(pierceCost[pierceCount]);
    //        buySpeedText.text = $"Buy ${pierceCost[pierceCount + 1] / 100f}";
    //        pierceCount++;
    //    }
    //}
}
