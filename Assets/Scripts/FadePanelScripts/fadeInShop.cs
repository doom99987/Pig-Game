using System.Collections;
using UnityEngine;

public class fadeInShop : MonoBehaviour
{
    [Header("Flash Time")]
    [SerializeField] private float flashTime = 1f;

    [Header("Sprite Renderer")]
    [SerializeField] private SpriteRenderer mySr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySr = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(fadeIn());
    }
    /// <summary>
    /// causes a fade in transperancy animation on the sprite
    /// </summary>
    /// <returns></returns>
    private IEnumerator fadeIn()
    {
        // current color of the sprite
        Color currentColor = new Color(0f, 0f, 0f, 1f);
        // loops over fading out the sprite
        for (float num = 1f; num >= 0f; num -= 0.01f)
        {
            currentColor = new Color(0f, 0f, 0f, num);
            // sets the sprite renderer
            mySr.color = currentColor;
            // delays the method
            yield return new WaitForSeconds(flashTime);
        }
    }
    /// <summary>
    /// causes a fade out transperancy animation on the sprite
    /// </summary>
    /// <returns></returns>
    private IEnumerator fadeOut()
    {
        Color currentColor = new Color(0f, 0f, 0f, 1f);
        for (float num = 0f; num <= 1f; num -= 0.01f)
        {
            currentColor = new Color(0f, 0f, 0f, num);
            mySr.color = currentColor;
            yield return new WaitForSeconds(flashTime);
        }
    }
}
