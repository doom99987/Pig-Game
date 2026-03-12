/****************************************************************************
* File Name: PanelManager.c
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script has all the functions to open and close panels.
*
****************************************************************************/
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject panel2;
    public bool panelOpen = false;

    public void openPanel()
    {
        panelOpen = true;
        panel.SetActive(true);
    }

    public void closePanel()
    {
        panelOpen = false;
        panel.SetActive(false);
    }

    public void togglePanel()
    {
        if (panelOpen)
        {
            closePanel();
        }
        else
        {
            openPanel();
        }
    }
}
