/****************************************************************************
* File Name: playScenePanelManager.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script has all the functions to open and close panels in the play scene, such as the shop panel, death, and victory panels.
*
****************************************************************************/
using System.Collections;
using TMPro;
using UnityEngine;

public class playScenePanelManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject deathPanel;
    [SerializeField] GameObject victoryPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject takeDmgPanel;
    [SerializeField] GameObject quitConfirmationPanel;

    private bool isShopOpen = false;
    private bool isDeathOpen = false;
    private bool isVictoryOpen = false;
    private bool isTutorialTextOn = false;
    private bool isPauseOpen = false;
    private bool isTakeDmgOpen = false;
    private bool isQuitConfirmationOpen = false;

    public void Start()
    {
        closeAllPanel();
    }

    /// <summary>
    /// Toggles the visibility of the shop panel.
    /// </summary>
    public void toggleShopPanel()
    {
        isShopOpen = !isShopOpen;
        shopPanel.SetActive(isShopOpen);

    }

    /// <summary>
    /// Toggles the visibility of the death panel.
    /// </summary>
    public void toggleDeathPanel()
    {
        isDeathOpen = !isDeathOpen;
        deathPanel.SetActive(isDeathOpen);
    }

    /// <summary>
    /// Toggles the visibility of the victory panel.
    /// </summary>
    public void toggleVictoryPanel()
    {
        isVictoryOpen = !isVictoryOpen;
        victoryPanel.SetActive(isVictoryOpen);
    }

    /// <summary>
    /// Closes all active UI panels, including shop, death, and victory panels.
    /// </summary>
    public void closeAllPanel()
    {
        shopPanel.SetActive(false);
        deathPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    /// <summary>
    /// toggles the visibility of the pause panel.
    /// </summary>
    public void togglePausePanel()
    {
        isPauseOpen = !isPauseOpen;
        gameObject.GetComponent<gameManager>().setGameState(isPauseOpen);
        pausePanel.SetActive(isPauseOpen);
    }

    public void toggleDmgPanel()
    {
        isTakeDmgOpen = !isTakeDmgOpen;
        takeDmgPanel.SetActive(isTakeDmgOpen);
    }

    public void toggleQuitConfirmationPanel()
    {
        isQuitConfirmationOpen = !isQuitConfirmationOpen;
        quitConfirmationPanel.SetActive(isQuitConfirmationOpen);
    }

    public bool getIsShopOpen()
    {
        return isShopOpen;
    }

    public bool getVictoryOpen()
    {
        return isVictoryOpen;
    }
    public bool getIsDeathOpen()
    {
        return isDeathOpen;
    }
    public bool getIsPauseOpen()
    {
        return isPauseOpen;
    }

}
