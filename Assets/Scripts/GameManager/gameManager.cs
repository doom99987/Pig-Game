/****************************************************************************
* File Name: gameManager.cs
* Author: Caleb Bohm
* DigiPen Email: caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: Manages the game being paused and the round being cleared
*
****************************************************************************/

using TMPro;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [Header("Game States")]
    [Tooltip("True = Game is Paused, False = Game is Unpaused")]
        [SerializeField] protected bool gamePaused;
    [Tooltip("Variable to check if the round has been cleared")]
        [SerializeField] protected bool roundClear;

    [Header("Toggle variables")]
    [SerializeField] protected bool isTutorialTextOn = false;
    [SerializeField] protected TextMeshProUGUI tutorialText;

    [Header("FadeManager")]
    [Tooltip("the object used for fading in and out")]
        [SerializeField] private GameObject fadeManager;

    private void Start()
    {
        fadeManager.SetActive(true);
        fadeManager.GetComponent<fadeInManager>().fadeOut();
    }

    public void Update() {
        //opening the pause menu when you press escape and the player is not dead and the shop and victory panels are not open
        if (Input.GetKeyDown(KeyCode.Escape) && gameObject.GetComponent<hpManager>().getIsDead() == false && 
           gameObject.GetComponent<playScenePanelManager>().getIsShopOpen() == false && gameObject.GetComponent<playScenePanelManager>().getVictoryOpen() == false)
        {
           gameObject.GetComponent<playScenePanelManager>().togglePausePanel();
           
        }
    }

    /// <summary>
    /// Tells you if the game is paused
    /// </summary>
    /// <returns></returns>
    public bool getGameState()
    {
        return gamePaused;
    }

    /// <summary>
    /// Tells you if you cleared a round
    /// </summary>
    /// <returns></returns>
    public bool getRoundClear()
    {
        return roundClear;
    }

    /// <summary>
    /// Called to set if the game is paused
    /// </summary>
    /// <param name="gameState"></param>
    public void setGameState(bool gameState)
    {
        gamePaused = gameState;
    }

    /// <summary>
    /// Called to set if the round is cleared and to set if the game is paused
    /// </summary>
    /// <param name="gameState"></param>
    public void setRoundClear(bool gameState)
    {
        roundClear = gameState;
        gamePaused = gameState;
    }

    /// <summary>
    /// when round end open shop panel
    /// </summary>
    public void roundEnded()
    {
        if (roundClear)
        {
            fadeManager.SetActive(true);
            fadeManager.GetComponent<fadeInManager>().fadeInShop();
        }
    }

    /// <summary>
    /// toggles the visibility of the tutorial text.
    /// </summary>
    public void toggleTutorialText()
    {
        isTutorialTextOn = !isTutorialTextOn;
        tutorialText.gameObject.SetActive(isTutorialTextOn);
    }
}

