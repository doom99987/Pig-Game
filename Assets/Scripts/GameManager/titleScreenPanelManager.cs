/****************************************************************************
* File Name: TitleScreenPanelManager.c
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script has all the functions to open and close panels on the Title Screen, such as the credits panel and the title screen panel.
*
****************************************************************************/
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [Header("Title Screen Panels")]
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject titleScreenPanel;
    public void openCreditsPanel()
    {
        creditsPanel.SetActive(true);
        titleScreenPanel.SetActive(false);
    }
    public void closeCreditsPanel() 
    { 
        creditsPanel.SetActive(false);
        titleScreenPanel.SetActive(true);
    }
}
