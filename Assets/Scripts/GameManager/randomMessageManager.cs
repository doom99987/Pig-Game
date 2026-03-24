/****************************************************************************
* File Name: randomMessageManager.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script randomises the message you get when you win or lose the game.
*
****************************************************************************/
using TMPro;
using UnityEngine;

public class randomMessageManager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private gameManager gameManager;
    [SerializeField] protected TextMeshProUGUI winMessageText;
    [SerializeField] protected TextMeshProUGUI loseMessageText;

    [Header("Messages")]
    [SerializeField] private string[] winMessages = { "you won!" };
    [SerializeField] private string[] loseMessages = { "you got robbed" };

    /// <summary>
    /// prints random win message to the screen when the player wins the game
    /// </summary>
    public void displayWinMessage()
    {
        int random = Random.Range(0, winMessages.Length);
        winMessageText.text = winMessages[random];
    }
    /// <summary>
    /// prints random lose message to the screen when the player loses the game
    /// </summary>
    public void displayLoseMessage()
    {
        int random = Random.Range(0, loseMessages.Length);
        loseMessageText.text = loseMessages[random];
    }
}
