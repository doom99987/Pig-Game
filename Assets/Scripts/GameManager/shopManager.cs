/****************************************************************************
* File Name: shopManager.cs
* Author: David Konvisser & Caleb Bohm
* DigiPen Email: david.konvisser@digipen.edu & caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: This script manages the shop, including the functions to buy upgrades for the player, such as speed, max HP, and healing. 
* It also keeps track of the counts for each upgrade to determine the cost of the next upgrade.
*
****************************************************************************/
using TMPro;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    [Header("bomb settings")]
    protected bool bombBought = false;
    [Tooltip("Total number of bombs you have")]
    [SerializeField] TextMeshProUGUI bombAmount;
    [SerializeField] GameObject bombAmountObject;
    [SerializeField] GameObject bombImage;

    [Header("Upgrade Limits")]
    [Tooltip("The maximum number of times the player can upgrade their speed.")]
        [SerializeField] protected int sCountMax = 10;
    [Tooltip("The maximum number of times the player can upgrade their hp.")]
        [SerializeField] protected int hCountMax = 10;
    [Tooltip("The maximum number of times the player can heal.")]
        [SerializeField] protected int healingCountMax = 10;
    [Tooltip("The maximum number of times the player can upgrade pierce.")]
        [SerializeField] protected int pierceCountMax = 10;
    [Tooltip("The maximum number of times the player can upgrade bullet damage")]
        [SerializeField] protected int bulletUpgradeCountMax = 10;
    [Tooltip("The maximum number of times the player can buy bombs")]
        [SerializeField] protected int bombCountMax = 10;

    [Header("References")]
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject player;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI buySpeedText;
    [SerializeField] TextMeshProUGUI buyHpText;
    [SerializeField] TextMeshProUGUI buyHealingText;
    [SerializeField] TextMeshProUGUI buyPierceText;
    [SerializeField] TextMeshProUGUI buyBulletUpgradeText;
    [SerializeField] TextMeshProUGUI buyBombText;

    [Header("Upgrade Costs")]
    [SerializeField] float[] speedCost = { 5, 50, 500, 5000, 50000, 500000 };
    [SerializeField] float[] hpCost = { 5, 50, 500, 5000, 50000, 500000 };
    [SerializeField] float[] healingCost = { 5, 50, 500, 5000, 50000, 500000 };
    [SerializeField] float[] pierceCost = { 5, 50, 500, 5000 };
    [SerializeField] float[] bulletUpgradeCost = { 5, 50, 500, 5000 };
    [SerializeField] float[] bombCost = { 5, 50, 500, 5000 };

    // all the counts for the upgrades, used to determine the cost of the next upgrade.
    protected int speedCount = 0;
    protected int hpBuyCount = 0;
    protected int healingCount = 0;
    protected int pierceCount = 0;
    protected int bulletUpgradeCount = 0;
    protected int bombCount = 0;

    private void Start()
    {
        buySpeedText.text = $"Buy ${speedCost[speedCount] / 100f}";
        buyHpText.text = $"Buy ${hpCost[hpBuyCount] / 100f}";
        buyHealingText.text = $"Buy ${healingCost[healingCount] / 100f}";
        buyPierceText.text = $"Buy ${pierceCost[pierceCount] / 100f}";
        buyBulletUpgradeText.text = $"Buy ${bulletUpgradeCost[bulletUpgradeCount] / 100f}";
        buyBombText.text = $"Buy ${bombCost[bombCount] / 100f}";
    }

    /// <summary>
    /// Called to upgrade the players speed by 1
    /// </summary>
    public void buySpeed()
    {
        if (gameManager.GetComponent<moneyManager>().getMoney() >= speedCost[speedCount] && speedCount < sCountMax - 1)
        {
            //upgrades the player's speed by 1.
            player.GetComponent<playerMovement>().setCurSpeed(player.GetComponent<playerMovement>().getCurrentSpeed() + 1);
            gameManager.GetComponent<moneyManager>().removeMoney(speedCost[speedCount]);
            buySpeedText.text = $"Buy ${speedCost[speedCount + 1] / 100f}";
            speedCount++;
        }
    }

    /// <summary>
    /// Called to upgrade the player max Hp by 1
    /// </summary>
    public void buyHp()
    {
        if (gameManager.GetComponent<moneyManager>().getMoney() >= hpCost[hpBuyCount] && (hpBuyCount < hCountMax - 3))
        {
            gameManager.GetComponent<hpManager>().upgradeMaxHp();
            gameManager.GetComponent<moneyManager>().removeMoney(hpCost[hpBuyCount]);
            buyHpText.text = $"Buy ${hpCost[hpBuyCount + 1] / 100f}";
            hpBuyCount++;
        }
    }

    /// <summary>
    /// Called to heal the players Hp by 1
    /// </summary>
    public void buyHealing()
    {
        if (gameManager.GetComponent<moneyManager>().getMoney() >= healingCost[healingCount] && healingCount < healingCountMax - 1)
        {
            gameManager.GetComponent<hpManager>().heal();
            gameManager.GetComponent<moneyManager>().removeMoney(healingCost[healingCount]);
            buyHealingText.text = $"Buy ${healingCost[healingCount + 1] / 100f}";
            healingCount++;
        }
    }

    /// <summary>
    /// Called to upgrade the amount of enemies the bullet pierces through by 1
    /// </summary>
    public void buyPierce()
    {
        if (gameManager.GetComponent<moneyManager>().getMoney() >= pierceCost[pierceCount] && pierceCount < pierceCountMax - 1)
        {
            gameManager.GetComponent<moneyManager>().removeMoney(pierceCost[pierceCount]);
            buyPierceText.text = $"Buy ${pierceCost[pierceCount + 1] / 100f}";
            pierceCount++;
        }
    }

    /// <summary>
    /// Called to upgrade the damage of the bullet
    /// </summary>
    public void buyBulletUpgrade()
    {
        if (gameManager.GetComponent<moneyManager>().getMoney() >= bulletUpgradeCost[bulletUpgradeCount] && bulletUpgradeCount < bulletUpgradeCountMax - 1)
        {
            gameManager.GetComponent<moneyManager>().removeMoney(bulletUpgradeCost[bulletUpgradeCount]);
            buyBulletUpgradeText.text = $"Buy ${bulletUpgradeCost[bulletUpgradeCount + 1] / 100f}";
            bulletUpgradeCount++;
        }
    }

    /// <summary>
    /// Called to buy 1 bomb
    /// </summary>
    public void buyBombs()
    {
        if (gameManager.GetComponent<moneyManager>().getMoney() >= bombCost[bombCount] && bombCount < bombCountMax - 1)
        {
            bombImage.SetActive(true);
            bombAmountObject.SetActive(true);
            bombAmount.SetText($"{bombCount + 1}");
            gameManager.GetComponent<moneyManager>().removeMoney(bombCost[bombCount]);
            buyBombText.text = $"Buy ${bombCost[bombCount + 1] / 100f}";
            bombCount++;
        }
    }

    /// <summary>
    /// Gives the current pierce level
    /// </summary>
    /// <returns></returns>
    public int getPierceCount()
    {
        return pierceCount;
    }

    /// <summary>
    /// Gives the current bulletUpgrade level
    /// </summary>
    /// <returns></returns>
    public int getBulletUpgradeCount()
    {
        return bulletUpgradeCount;
    }

    public int getBombCount()
    {
        return bombCount;
    }

    public void subtractBombCount(int amount)
    {
        if(bombCount - amount < 0)
        {
            bombCount = 0;
        }
        bombCount = bombCount - amount;
        bombAmount.text = $"{bombCount}";
    }
}
