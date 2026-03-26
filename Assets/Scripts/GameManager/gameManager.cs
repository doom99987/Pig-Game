/****************************************************************************
* File Name: gameManager.cs
* Author: Caleb Bohm
* DigiPen Email: caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: Manages the game being paused and the round being cleared
*
****************************************************************************/

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class gameManager : MonoBehaviour
{
    [Header("Game States")]
    [Tooltip("True = Game is Paused, False = Game is Unpaused")]
    [SerializeField] protected bool gamePaused;
    [Tooltip("Variable to check if the round has been cleared")]
    [SerializeField] protected bool roundClear;

    [SerializeField] protected bool isTutorialTextOn = false;
    [SerializeField] protected TextMeshProUGUI tutorialText;

    public void Update() {
       if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && gameObject.GetComponent<hpManager>().getIsDead() == false)
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
            gameObject.GetComponent<playScenePanelManager>().toggleShopPanel();
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

