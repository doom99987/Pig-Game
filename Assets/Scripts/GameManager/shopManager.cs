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
    [Tooltip("Total number of bombs you have")]
    [SerializeField] TextMeshProUGUI bombAmount;
    [SerializeField] GameObject bombAmountObject;
    [SerializeField] GameObject bombImage;

    [Header("Upgrade Limits")]
    [Tooltip("The maximum number of times the player can upgrade their speed.")]
        [SerializeField] private int sCountMax = 10;
    [Tooltip("The maximum number of times the player can upgrade their hp.")]
        [SerializeField] private int hCountMax = 10;
    [Tooltip("The maximum number of times the player can heal.")]
        [SerializeField] private int healingCountMax = 10;
    [Tooltip("The maximum number of times the player can upgrade pierce.")]
        [SerializeField] private int pierceCountMax = 10;
    [Tooltip("The maximum number of times the player can upgrade bullet damage")]
        [SerializeField] private int bulletUpgradeCountMax = 10;
    [Tooltip("The maximum number of times the player can buy bombs")]
        [SerializeField] private int bombCountMax = 10;

    [Header("References")]
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject player;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI buySpeedText;
    [SerializeField] private TextMeshProUGUI buyHpText;
    [SerializeField] private TextMeshProUGUI buyHealingText;
    [SerializeField] private TextMeshProUGUI buyPierceText;
    [SerializeField] private TextMeshProUGUI buyBulletUpgradeText;
    [SerializeField] private TextMeshProUGUI buyBombText;

    [Header("Upgrade Costs")]
    [SerializeField] private float[] speedCost = { 5, 50, 500, 5000, 50000, 500000 };
    [SerializeField] private float[] hpCost = { 5, 50, 500, 5000, 50000, 500000 };
    [SerializeField] private float[] healingCost = { 5, 50, 500, 5000, 50000, 500000 };
    [SerializeField] private float[] pierceCost = { 5, 50, 500, 5000 };
    [SerializeField] private float[] bulletUpgradeCost = { 5, 50, 500, 5000 };
    [SerializeField] private float[] bombCost = { 5, 50, 500, 5000 };

    // all the counts for the upgrades, used to determine the cost of the next upgrade.
    private int speedCount = 0;
    private int hpBuyCount = 0;
    private int healingCount = 0;
    private int pierceCount = 0;
    private int bulletUpgradeCount = 0;
    private int bombCount = 0;

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
        else if (speedCount >= sCountMax - 1)
        {
            buySpeedText.text = "Max Level";
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
        else if (hpBuyCount >= hCountMax - 3)
        {
            buyHpText.text = "Max Level";
        }
        }

    /// <summary>
    /// Called to heal the players Hp by 1
    /// </summary>
    public void buyHealing()
    {
        if ((gameManager.GetComponent<moneyManager>().getMoney() >= healingCost[healingCount] && healingCount < healingCountMax - 1) && gameManager.GetComponent<hpManager>().getCurrentHp() < gameManager.GetComponent<hpManager>().getMaxHp())
        {
            gameManager.GetComponent<hpManager>().heal();
            gameManager.GetComponent<moneyManager>().removeMoney(healingCost[healingCount]);
            buyHealingText.text = $"Buy ${healingCost[healingCount + 1] / 100f}";
            healingCount++;
        }
        else if (healingCount >= healingCountMax - 1)
        {
            buyHealingText.text = "Max Level";
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
        else if (pierceCount >= pierceCountMax - 1)
        {
            buyPierceText.text = "Max Level";
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
        else if (bulletUpgradeCount >= bulletUpgradeCountMax - 1)
        {
            buyBulletUpgradeText.text = "Max Level";
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
        else if (bombCount >= bombCountMax - 1)
        {
            buyBombText.text = "Max Level";
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

    /// <summary>
    /// Gives the current amount of bombs
    /// </summary>
    /// <returns></returns>
    public int getBombCount()
    {
        return bombCount;
    }

    /// <summary>
    /// Retracts from the amount of bombs you have
    /// </summary>
    /// <param name="amount">amount to remove</param>
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
