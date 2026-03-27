/****************************************************************************
* File Name: moneyManager.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script manages the player's money, including displaying the money on the UI, 
* adding and removing money, and toggling the money text on and off.
*
****************************************************************************/
using TMPro;
using UnityEngine;

public class moneyManager : MonoBehaviour
{
    [Header("Money")]
    protected bool isMoneyTextOn = true;
    [SerializeField] float money = 2500f;
    [SerializeField] TextMeshProUGUI moneyText;

    /// <summary>
    /// updates money. 
    /// </summary>
    void Update()
    {
        moneyText.text = $"${money / 100f}";
    }

    /// <summary>
    /// adds money to the player.
    /// <param name="amount"></param>
    public void addMoney(float amount)
    {
        money += amount;
    }

    /// <summary>
    /// removes money from the player.
    /// </summary>
    /// <param name="amount"></param>
    public void removeMoney(float amount)
    {
        money -= amount;
    }

    /// <summary>
    /// getter for the player's current money.
    /// </summary>
    /// <returns></returns>
    public float getMoney()
    {
        return money;
    }

    /// <summary>
    /// Toggles the visibility of the money text on the UI. 
    /// It switches the active state of the money text game object and updates the isMoneyTextOn boolean accordingly.
    /// </summary>
    public void toggleMoneyText()
    {
        isMoneyTextOn = !isMoneyTextOn;
        moneyText.gameObject.SetActive(isMoneyTextOn);
    }
}
