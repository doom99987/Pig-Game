/****************************************************************************
* File Name: TitleScreenPanelManager.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script has all the functions to open and close panels on the Title Screen, such as the credits panel and the title screen panel.
*
****************************************************************************/
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [Header("Title Screen Panels")]
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject titleScreenPanel;
    protected bool isCreditsOpen = false;
    public void toggleCreditsPanel()
    {
        isCreditsOpen = !isCreditsOpen;
        creditsPanel.SetActive(isCreditsOpen);
        titleScreenPanel.SetActive(!isCreditsOpen);
    }
}
