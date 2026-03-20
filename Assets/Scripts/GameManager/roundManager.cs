/****************************************************************************
* File Name: roundManager.cs
* Author: Caleb Bohm
* DigiPen Email: caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: Manages the round timer, ends the round, and opens
*              the victory panel after a certain amount of rounds
*
****************************************************************************/

using UnityEngine;
using TMPro;

public class roundManager : MonoBehaviour
{
    protected float elapsedTime;

    [Header("Round")]
    [Tooltip("Current Round")]
    [SerializeField] protected int round = 0;

    [Tooltip(("Total number of Rounds"))]
    [SerializeField] protected int totalRounds = 0;

    [Tooltip("Amount of time in a Round")]
    [SerializeField] protected float roundTime = 121f;

    [Header("Text Timer")]
    [Tooltip("The Textbox for the Timer")]
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI roundText;
    [SerializeField] TextMeshProUGUI deathText;

    [Header("End of Round Bonus")]
    [Tooltip("The amount of money given at the end of each round")]
    [SerializeField] float[] endOfRoundBonus = { 5, 50, 500, 5000, 50000, 500000, 50000000, 50000000, 50000000, 5000000, 5000000};

    // Run is called before any update is called the first time
    private void Start()
    {
        roundText.text = "Round: " + round + "/" + totalRounds;
        elapsedTime = roundTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the game is paused
        if (!gameObject.GetComponent<gameManager>().getGameState())
        {
            // Updates the total time thats passed
            elapsedTime -= Time.deltaTime;

            // Displays the Time in 0:00 format
            int minutes = Mathf.FloorToInt((elapsedTime) / 60);
            int seconds = Mathf.FloorToInt((elapsedTime) % 60);
            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            deathText.text = string.Format("you had: " + "{0:0}:{1:00}", minutes, seconds + " seconds left");
            // Checks if the round needs to be ended
            if (elapsedTime < 1)
            {
                gameObject.GetComponent<gameManager>().setRoundClear(true);
                if (round == totalRounds)
                {
                    gameObject.GetComponent<moneyManager>().toggleMoneyText();
                    gameObject.GetComponent<playScenePanelManager>().toggleShopPanel();
                    gameObject.GetComponent<playScenePanelManager>().toggleVictoryPanel();
                }
                else
                {
                    gameObject.GetComponent<gameManager>().roundEnded();
                    resetTimer();
                    if(endOfRoundBonus.Length > round)
                    {
                        gameObject.GetComponent<moneyManager>().addMoney(endOfRoundBonus[round]);
                    }
                    round++;
                    roundText.text = "Round: " + round + "/" + totalRounds;

                }
            }
        }
    }
    /// <summary>
    /// Resets the Timer
    /// </summary>
    public void resetTimer()
    {
        elapsedTime = roundTime;
    }
    /// <summary>
    /// gets the current round
    /// </summary>
    /// <returns></returns>
    public int getRound()
    {
               return round;
    }
}

