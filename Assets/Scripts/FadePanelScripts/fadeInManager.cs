using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class fadeInManager : MonoBehaviour
{
    [Header("Flash Time")]
    [Tooltip("speed at which the fade in goes at")]
        [SerializeField] private float flashTime = 1f;

    private Image img;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Gets the objects img
        img = gameObject.GetComponent<Image>();
        // Fades the object out
        StartCoroutine(cfadeOut());
    }
    /// <summary>
    /// makes the object fade Out
    /// </summary>
    public void fadeOut()
    {
        StartCoroutine(cfadeOut());
    }
    /// <summary>
    /// makes the object fade in
    /// </summary>
    public void fadeIn()
    {
        StartCoroutine(cfadeIn());
    }
    /// <summary>
    /// causes a fade in transperancy animation on the sprite
    /// </summary>
    /// <returns></returns>
    private IEnumerator cfadeOut()
    {
        // current color of the img
        Color currentColor = new Color(0f, 0f, 0f, 1f);
        // loops over fading out the img
        for (float num = 1f; num >= 0f; num -= 0.01f)
        {
            // sets the color of the img
            currentColor = new Color(0f, 0f, 0f, num);
            img.color = currentColor;
            // delays the method
            yield return new WaitForSeconds(flashTime);
        }
    }
    /// <summary>
    /// causes a fade out transperancy animation on the sprite
    /// </summary>
    /// <returns></returns>
    private IEnumerator cfadeIn()
    {
        // current color of the img
        Color currentColor = new Color(0f, 0f, 0f, 1f);
        // loops over fading in the img
        for (float num = 0f; num <= 1f; num -= 0.01f)
        {
            // Sets the current color
            currentColor = new Color(0f, 0f, 0f, num);
            img.color = currentColor;
            // delays the method
            yield return new WaitForSeconds(flashTime);
        }
    }
}
