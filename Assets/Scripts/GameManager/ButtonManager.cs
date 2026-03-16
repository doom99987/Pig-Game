/****************************************************************************
* File Name: ButtonManager.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script has all the button manager functions.
*
****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public static void goToPlayScene()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public static void closeGame()
    {
        Application.Quit();
    }

    public static void goToTitleScreen()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
