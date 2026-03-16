/****************************************************************************
* File Name: playScenePanelManager.c
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
    public void toggleShopPanel()
    {
        isShopOpen = !isShopOpen;
        shopPanel.SetActive(isShopOpen);

    }
    public void toggleDeathPanel()
    {
        isDeathOpen = !isDeathOpen;
        deathPanel.SetActive(isDeathOpen);
    }
    public void toggleVictoryPanel()
    {
        isVictoryOpen = !isVictoryOpen;
        victoryPanel.SetActive(isVictoryOpen);
    }
    public void closeAllPanel()
    {
        shopPanel.SetActive(false);
        deathPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }
}
