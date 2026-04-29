/****************************************************************************
* Name: playScenePanelManager.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script has all the functions to open and close panels in the play scene, such as the shop panel, death, and victory panels.
*
****************************************************************************/
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
    [SerializeField] GameObject dmgInfoPanel;
    [SerializeField] GameObject healingInfoPanel;
    [SerializeField] GameObject pierceInfoPanel;
    [SerializeField] GameObject speedInfoPanel;
    [SerializeField] GameObject hpUpInfoPanel;
    [SerializeField] GameObject bombSkillInfoPanel;

    //bools to keep track of which panels are open, used for toggling the panels on and off.
    private bool isShopOpen = false;
    private bool isDeathOpen = false;
    private bool isVictoryOpen = false;
    private bool isPauseOpen = false;
    private bool isTakeDmgOpen = false;
    private bool isQuitConfirmationOpen = false;
   

    public void Start()
    {
        closeAllPanel();
        closeAllInfoPanels();
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

    /// <summary>
    /// toggles dmg panel
    /// </summary>
    public void toggleDmgPanel()
    {
        isTakeDmgOpen = !isTakeDmgOpen;
        takeDmgPanel.SetActive(isTakeDmgOpen);
    }

    /// <summary>
    /// toggles quit confirmation panel
    /// </summary>
    public void toggleQuitConfirmationPanel()
    {
        isQuitConfirmationOpen = !isQuitConfirmationOpen;
        quitConfirmationPanel.SetActive(isQuitConfirmationOpen);
    }

    /// <summary>
    /// generic function to toggle any panel on or off, mostly used for panels that are activated by buttons.
    /// </summary>
    /// <param name="panel"></param>
    public void togglePanel(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }

    /// <summary>
    /// toggles the shop off used for turning off the shop panel when the rounds over and goes to the victory panel.
    /// </summary>
    public void toggleShopOff()
    {
        shopPanel.SetActive(false);
    }

    /// <summary>
    /// closes all the panels that show the info about the different upgrades and skills, such as the damage upgrade, healing upgrade, and bomb skill.
    /// </summary>
    public void closeAllInfoPanels()
    {
        dmgInfoPanel.SetActive(false);
        healingInfoPanel.SetActive(false);
        pierceInfoPanel.SetActive(false);
        speedInfoPanel.SetActive(false);
        hpUpInfoPanel.SetActive(false);
        bombSkillInfoPanel.SetActive(false);
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
