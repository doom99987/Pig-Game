/****************************************************************************
* File Name: fadeInManager.cs
* Author: Caleb Bohm
* DigiPen Email: caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: fades in and out panels
*
****************************************************************************/

using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeInManager : MonoBehaviour
{
    [Header("Flash Time")]
    [Tooltip("speed at which the fade in goes at")]
        [SerializeField] private float flashTime = 1f;
    
    [Header("Image")]
    [Tooltip("The image we are going to fade in/out")]
        [SerializeField] Image img;

    [Header("Game Manager")]
    [SerializeField] private GameObject gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Gets the objects img
        img = gameObject.GetComponent<Image>();
    }
    /// <summary>
    /// makes the object fade Out
    /// </summary>
    public void fadeOut()
    {
        StartCoroutine(cfadeOut());
    }

    public void fadeInSceneSwap()
    {
        StartCoroutine(cfadeInSceneSwap());
    }
    /// <summary>
    /// makes the object fade in
    /// </summary>
    public void fadeIn()
    {
        StartCoroutine(cfadeIn());
    }
    /// <summary>
    /// Opens the shop with a fade in
    /// </summary>
    public void fadeInShop()
    {
        StartCoroutine(cfadeInShop());
    }

    public void fadeInDeath()
    {
        StartCoroutine(cfadeInDeath());
    }

    public void fadeInVictory()
    {
        StartCoroutine(cfadeInVictory());
    }

    /// <summary>
    /// causes a fade in transperancy animation on the sprite
    /// </summary>
    /// <returns></returns>
    private IEnumerator cfadeOut()
    {
        // current color of the img
        Color currentColor;
        // loops over fading out the img
        for (float num = 1f; num >= 0f; num -= 0.01f)
        {
            // sets the color of the img
            currentColor = new Color(0f, 0f, 0f, num);
            img.color = currentColor;
            // delays the method
            yield return new WaitForSeconds(flashTime);
        }
        gameObject.SetActive(false);
    }
    /// <summary>
    /// causes a fade out transperancy animation on the sprite
    /// </summary>
    /// <returns></returns>
    private IEnumerator cfadeIn()
    {
        // current color of the img
        Color currentColor;
        // loops over fading in the img
        for (float num = 0f; num <= 1f; num += 0.01f)
        {
            // Sets the current color
            currentColor = new Color(0f, 0f, 0f, num);
            img.color = currentColor;
            // delays the method
            yield return new WaitForSeconds(flashTime);
        }
    }
    /// <summary>
    /// Fades In and swaps to the play scene
    /// </summary>
    /// <returns></returns>
    private IEnumerator cfadeInSceneSwap()
    {
        // current color of the img
        Color currentColor;
        // loops over fading in the img
        for (float num = 0f; num <= 1f; num += 0.01f)
        {
            // Sets the current color
            currentColor = new Color(0f, 0f, 0f, num);
            img.color = currentColor;
            // delays the method
            yield return new WaitForSeconds(flashTime);
        }
        SceneManager.LoadScene("PlayScene");
    }
    /// <summary>
    /// Fades in the shop
    /// </summary>
    /// <returns></returns>
    private IEnumerator cfadeInShop()
    {
        // current color of the img
        Color currentColor;
        // loops over fading in the img
        for (float num = 0f; num <= 1f; num += 0.01f)
        {
            // Sets the current color
            currentColor = new Color(0f, 0f, 0f, num);
            img.color = currentColor;
            // delays the method
            yield return new WaitForSeconds(flashTime);
        }
        // Opens the shop panel
        gameManager.GetComponent<roundManager>().toggleRoundText();
        gameManager.GetComponent<roundManager>().toggleTimerText();
        gameManager.GetComponent<playScenePanelManager>().toggleShopPanel();
        // loops over fading out the img
        for (float num = 1f; num >= 0f; num -= 0.01f)
        {
            // sets the color of the img
            currentColor = new Color(0f, 0f, 0f, num);
            img.color = currentColor;
            // delays the method
            yield return new WaitForSeconds(flashTime);
        }
        gameObject.SetActive(false);
    }

    private IEnumerator cfadeInDeath()
    {
        // current color of the img
        Color currentColor;
        // loops over fading in the img
        for (float num = 0f; num <= 1f; num += 0.01f)
        {
            // Sets the current color
            currentColor = new Color(0f, 0f, 0f, num);
            img.color = currentColor;
            // delays the method
            yield return new WaitForSeconds(flashTime);
        }
        // Opens the death panel
        gameManager.GetComponent<playScenePanelManager>().toggleDeathPanel();
        // loops over fading out the img
        for (float num = 1f; num >= 0f; num -= 0.01f)
        {
            // sets the color of the img
            currentColor = new Color(0f, 0f, 0f, num);
            img.color = currentColor;
            // delays the method
            yield return new WaitForSeconds(flashTime);
        }
        gameObject.SetActive(false);
    }

    private IEnumerator cfadeInVictory()
    {
        // current color of the img
        Color currentColor;
        // loops over fading in the img
        for (float num = 0f; num <= 1f; num += 0.01f)
        {
            // Sets the current color
            currentColor = new Color(0f, 0f, 0f, num);
            img.color = currentColor;
            // delays the method
            yield return new WaitForSeconds(flashTime);
        }
        // Opens the death panel
        gameManager.GetComponent<playScenePanelManager>().toggleVictoryPanel();
        // loops over fading out the img
        for (float num = 1f; num >= 0f; num -= 0.01f)
        {
            // sets the color of the img
            currentColor = new Color(0f, 0f, 0f, num);
            img.color = currentColor;
            // delays the method
            yield return new WaitForSeconds(flashTime);
        }
        gameObject.SetActive(false);
    }
}
