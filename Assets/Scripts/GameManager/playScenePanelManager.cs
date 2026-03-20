/****************************************************************************
* File Name: playScenePanelManager.cs
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
    protected bool isShopOpen = false;
    protected bool isDeathOpen = false;
    protected bool isVictoryOpen = false;

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
}
