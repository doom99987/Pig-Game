/****************************************************************************
* Name: shopManager.cs
* Author: David Konvisser & Caleb Bohm
* DigiPen Email: david.konvisser@digipen.edu & caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: This script manages the shop, including the functions to buy upgrades for the player, such as speed, max HP, and healing. 
* It also keeps track of the counts for each upgrade to determine the cost of the next upgrade.
*
****************************************************************************/
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour
{



    [Header("Upgrade Costs")]
    [Tooltip("The Shop Upgrades")]
    [SerializeField] private upgrade[] upgrades;
    /// <summary>
    /// holds the cost for the upgrade
    /// </summary>
    [System.Serializable] private struct upgrade
    {
        [SerializeField] private string name;
        [SerializeField] public int[] cost;
    } 
    /// <summary>
    /// holds the array value for all the upgrades
    /// </summary>
    private enum u
    {
        speed, hp, healing, pierce, bulletUpgrade, bomb
    }

    [Header("Upgrade Amounts")]
    [Tooltip("The amount the player's speed increases by when buying a speed upgrade.")]
        [SerializeField] private float speedAmount = 1f;
    [Tooltip("Total number of bombs you have")]
        [SerializeField] TextMeshProUGUI bombAmount;

    [Header("bomb settings")]
    [SerializeField] GameObject bombAmountObject;
    [SerializeField] GameObject bombImage;

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

    //upgrade limits
    private int sCountMax;
    private int hCountMax;
    private int healingCountMax;
    private int pierceCountMax;
    private int bulletUpgradeCountMax;
    private int bombCountMax;

    // all the counts for the upgrades, used to determine the cost of the next upgrade.
    private int speedCount = 0;
    private int hpBuyCount = 0;
    private int healingCount = 0;
    private int pierceCount = 0;
    private int bulletUpgradeCount = 0;
    private int bombCount = 0;

    private void Start()
    {
        //sets all the max counts for the upgrades based on the length of the cost arrays,
        sCountMax = upgrades[(int)u.speed].cost.Length;
        hCountMax = upgrades[1].cost.Length;
        healingCountMax = upgrades[2].cost.Length;
        pierceCountMax = upgrades[3].cost.Length;
        bulletUpgradeCountMax = upgrades[4].cost.Length;
        bombCountMax = upgrades[5].cost.Length;

        //sets the text for each upgrade button to show the cost of the first upgrade.
        buySpeedText.text = $"Buy ${upgrades[(int)u.speed].cost[speedCount] / 100f}";
        buyHpText.text = $"Buy ${upgrades[(int)u.hp].cost[hpBuyCount] / 100f}";
        buyHealingText.text = $"Buy ${upgrades[(int)u.healing].cost[healingCount] / 100f}";
        buyPierceText.text = $"Buy ${upgrades[(int)u.pierce].cost[pierceCount] / 100f}";
        buyBulletUpgradeText.text = $"Buy ${upgrades[(int)u.bulletUpgrade].cost[bulletUpgradeCount] / 100f}";
        buyBombText.text = $"Buy ${upgrades[(int)u.bomb].cost[bombCount] / 100f}";
    }

    /// <summary>
    /// Called to upgrade the players speed by 1
    /// </summary>
    public void buySpeed()
    {
        if (gameManager.GetComponent<moneyManager>().getMoney() >= upgrades[(int)u.speed].cost[speedCount] && speedCount < sCountMax - 1)
        {
            //upgrades the player's speed by 1.
            player.GetComponent<playerMovement>().setCurSpeed(player.GetComponent<playerMovement>().getCurrentSpeed() + speedAmount);
            gameManager.GetComponent<moneyManager>().removeMoney(upgrades[(int)u.speed].cost[speedCount]);
            buySpeedText.text = $"Buy ${upgrades[(int)u.speed].cost[speedCount + 1] / 100f}";
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
        if (gameManager.GetComponent<moneyManager>().getMoney() >= upgrades[(int)u.hp].cost[hpBuyCount] && (hpBuyCount < hCountMax - 3))
        {
            gameManager.GetComponent<hpManager>().upgradeMaxHp();
            gameManager.GetComponent<moneyManager>().removeMoney(upgrades[(int)u.hp].cost[hpBuyCount]);
            buyHpText.text = $"Buy ${upgrades[(int)u.hp].cost[hpBuyCount + 1] / 100f}";
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
        //checks if they have enough money, if they are not at max healing level, and if their current Hp is less than their max Hp before allowing them to buy healing.
        if ((gameManager.GetComponent<moneyManager>().getMoney() >= upgrades[(int)u.healing].cost[healingCount] && healingCount < healingCountMax - 1) 
            && gameManager.GetComponent<hpManager>().getCurrentHp() < gameManager.GetComponent<hpManager>().getMaxHp())
        {
            gameManager.GetComponent<hpManager>().heal();
            gameManager.GetComponent<moneyManager>().removeMoney(upgrades[(int)u.healing].cost[healingCount]);
            buyHealingText.text = $"Buy ${upgrades[(int)u.healing].cost[healingCount + 1] / 100f}";
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
        if (gameManager.GetComponent<moneyManager>().getMoney() >= upgrades[(int)u.pierce].cost[pierceCount] && pierceCount < pierceCountMax - 1)
        {
            gameManager.GetComponent<moneyManager>().removeMoney(upgrades[(int)u.pierce].cost[pierceCount]);
            buyPierceText.text = $"Buy ${upgrades[(int)u.pierce].cost[pierceCount + 1] / 100f}";
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
        if (gameManager.GetComponent<moneyManager>().getMoney() >= upgrades[(int)u.bulletUpgrade].cost[bulletUpgradeCount] && bulletUpgradeCount < bulletUpgradeCountMax - 1)
        {
            gameManager.GetComponent<moneyManager>().removeMoney(upgrades[(int)u.bulletUpgrade].cost[bulletUpgradeCount]);
            buyBulletUpgradeText.text = $"Buy ${upgrades[(int)u.bulletUpgrade].cost[bulletUpgradeCount + 1] / 100f}";
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
        if (gameManager.GetComponent<moneyManager>().getMoney() >= upgrades[(int)u.bomb].cost[bombCount] && bombCount < bombCountMax - 1)
        {
            bombImage.SetActive(true);
            bombAmountObject.SetActive(true);
            bombAmount.SetText($"{bombCount + 1}");
            gameManager.GetComponent<moneyManager>().removeMoney(upgrades[(int)u.bomb].cost[bombCount]);
            buyBombText.text = $"Buy ${upgrades[(int)u.bomb].cost[bombCount + 1] / 100f}";
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
        if (bombCount - amount < 0)
        {
            bombCount = 0;
        }
        bombCount = bombCount - amount;
        bombAmount.text = $"{bombCount}";
    }
}
