/****************************************************************************
* File Name: ButtonManager.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script has all the button manager functions.
*
****************************************************************************/
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [Header("GameManager")]
    [SerializeField] private GameObject gameManager;

    [Header("FadeSceneManager")]
    [SerializeField] private GameObject fadeManager;
    public void goToPlayScene()
    {
        fadeManager.SetActive(true);
        fadeManager.GetComponent<fadeInManager>().fadeInSceneSwap();
    }

    public static void closeGame()
    {
        Application.Quit();
    }

    public static void goToTitleScreen()
    {
        SceneManager.LoadScene("TitleScene");
    }

    /// <summary>
    /// closes the shop panel and sets round clear to false, allowing the player to continue to the next round.
    /// </summary>
    public void closeShop()
    {
        gameManager.GetComponent<playScenePanelManager>().toggleShopPanel();
        gameManager.GetComponent<roundManager>().toggleRoundText();
        gameManager.GetComponent<roundManager>().toggleTimerText();
        gameManager.GetComponent<gameManager>().setRoundClear(false);
    }

    public void restart()
    {
               SceneManager.LoadScene("PlayScene");
    }
}
