/****************************************************************************
* Name: roundManager.cs
* Author: Caleb Bohm & David Konvisser
* DigiPen Email: caleb.bohm@digipen.edu & david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: Manages the round timer, ends the round, and opens
*              the victory panel after a certain amount of rounds
*
****************************************************************************/
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class roundManager : MonoBehaviour
{

    [Header("Round")]
    [Tooltip("Current Round")]
    [SerializeField] private int round = 0;

    [Tooltip(("Total number of Rounds"))]
    [SerializeField] private int totalRounds = 0;

    [Tooltip("Time")]
    [SerializeField] private float startDelayTime = 5f;
    [SerializeField] private float roundTime = 121f;

    [Header("End of Round Bonus")]
    [Tooltip("The amount of money given at the end of each round")]
        [SerializeField] float[] endOfRoundBonus = { 5, 50, 500, 5000, 50000, 500000, 50000000, 50000000, 50000000, 5000000, 5000000 };

    [Header("Necessities")]
    [SerializeField] Transform heartsContainer;
    [SerializeField] private GameObject fadePanel;
    [Tooltip("The Textbox for the Timer")]
        [SerializeField] private TextMeshProUGUI timerText;
    [Tooltip("The Textbox for the current round")]
        [SerializeField] private TextMeshProUGUI roundText;
    [Tooltip("The Textbox for the death text")]
        [SerializeField] private TextMeshProUGUI deathText;
    [SerializeField] private GameObject tutorialStuff;

    [Header("Sound")]
    [SerializeField] private AudioSource mainGpSound;

    private List<GameObject> things = new List<GameObject>();
    private float elapsedTime;
    private bool roundStartDelay = true;
    private bool isRoundTextOpen = true;
    private bool isTimerTextOpen = true;

    // Run is called before any update is called the first time
    private void Start()
    {
        // Displays the current round and sets the timer
        roundText.text = "Round: " + round + "/" + totalRounds;
        elapsedTime = roundTime;
        tutorialStuff.SetActive(true);
        StartCoroutine(startDelay());
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the game is paused
        if (!gameObject.GetComponent<gameManager>().getGameState() && !roundStartDelay)
        {
            tutorialStuff.SetActive(false);
            // Updates the total time thats passed
            elapsedTime -= Time.deltaTime;

            // Displays the Time in 0:00 format
            int minutes = Mathf.FloorToInt((elapsedTime) / 60);
            int seconds = Mathf.FloorToInt((elapsedTime) % 60);
            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            // Displays the time on the deathscreen
            if (deathText != null)
            {
                deathText.text = string.Format("You had: " + "{00}", seconds + " seconds left");
            }
            // Checks if the round needs to be ended
            if (elapsedTime < 1)
            {
                gameObject.GetComponent<gameManager>().setRoundClear(true);
                // Check if they beat final round
                if (round == totalRounds)
                {
                    foreach (Transform child in heartsContainer)
                        Destroy(child.gameObject);
                    gameObject.GetComponent<roundManager>().toggleRoundText();
                    gameObject.GetComponent<roundManager>().toggleTimerText();
                    gameObject.GetComponent<moneyManager>().toggleMoneyText();
                    gameObject.GetComponent<playScenePanelManager>().toggleShopOff();
                    fadePanel.SetActive(true);
                    fadePanel.GetComponent<fadeInManager>().fadeInVictory();
                }
                // Otherwise go to next round
                else
                {
                    // Opens shop panel
                    gameObject.GetComponent<gameManager>().roundEnded();
                    resetTimer();
                    // Check if the round number is within the end of round bonus
                    if (endOfRoundBonus.Length > round)
                    {
                        gameObject.GetComponent<moneyManager>().addMoney(endOfRoundBonus[round]);
                    }

                    round++;
                    // Display current round
                    roundText.text = "Round: " + round + "/" + totalRounds;
                    // Destroys all the objects in the list of things to be destroyed at the end of the round
                    for (int i = 0; i < things.Count; i++)
                    {
                        if (things[i] != null)
                        {
                            Destroy(things[i]);
                        }

                    }
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

    /// <summary>
    /// toggles the round text on and off
    /// </summary>
    public void toggleRoundText()
    {
        isRoundTextOpen = !isRoundTextOpen;
        roundText.gameObject.SetActive(isRoundTextOpen);
    }

    /// <summary>
    /// toggles the timer text on and off
    /// </summary>
    public void toggleTimerText()
    {
        isTimerTextOpen = !isTimerTextOpen;
        timerText.gameObject.SetActive(isTimerTextOpen);
    }

    /// <summary>
    /// adds objects to a list to be destroyed at the end of the round
    /// </summary>
    /// <param name="thing"></param>
    public void getObjects(GameObject thing)
    {
        things.Add(thing);
    }

    public bool getStartDelay()
    {
        return roundStartDelay;
    }

    /// <summary>
    /// delays the start of the round
    /// </summary>
    /// <returns></returns>
    private IEnumerator startDelay()
    {
        yield return new WaitForSeconds(startDelayTime);
        // Starts the round
        roundStartDelay = false;
    }
}

