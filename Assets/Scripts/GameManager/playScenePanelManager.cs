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
    public void openShopPanel()
    {
        shopPanel.SetActive(true);
    }
    public void openDeathPanel()
    {
        deathPanel.SetActive(true);
    }
    public void openVictoryPanel()
    {
        deathPanel.SetActive(true);
    }
    public void closeAllPanel()
    {
        shopPanel.SetActive(false);
        deathPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }
    public void closeShopPanel()
    {
        shopPanel.SetActive(false);
    }
    public void closeDeathPanel()
    {
        deathPanel.SetActive(false);
    }
    public void closeVictoryPanel()
    {
        victoryPanel.SetActive(false);
    }
}
