/****************************************************************************
* File Name: hpManager.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: this script manages the player's HP, including displaying the hearts on the UI, taking damage, healing, and upgrading max HP. 
* It also handles the player's death by toggling the death panel and money text when HP reaches 0.
*
****************************************************************************/
using System.Collections;
using TMPro;
using UnityEngine;
public class hpManager : MonoBehaviour
{
    [Header("HP Settings")]
    [Tooltip("Current HP of the player.")]
        [SerializeField] private int hp = 3;
    [Tooltip("Maximum HP of the player.")]
        [SerializeField] private int maxHp = 3;
    [Tooltip("Number of hearts to display per row in the UI.")]
        [SerializeField] private int heartsPerRow = 4;

    [Header("Heart Prefabs")]
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private GameObject emptyHeartPrefab;
    [SerializeField] private Transform heartsContainer;

    [Header("Damage Flash")]
    [SerializeField] private Color damageColor;
    [SerializeField] private SpriteRenderer playerHit;
    [Tooltip("How long till the flash reaches maximum color")]
        [SerializeField] private float maxFlashTime = 1;
    [Tooltip("How long till the flash reaches minimum color")]
        [SerializeField] private float minFlashTime = 1;
    [Tooltip("Max color the thing will flash")]
    [SerializeField] private Color maxFlashColor;

    [Header("Extra Necessities")]
    [SerializeField] private GameObject gameManager;
    [SerializeField] private TextMeshProUGUI deathPanelMoneyText;

    private GameObject[] fullHearts;
    private GameObject[] emptyHearts;
    private bool isDead = false;

    void Start()
    {
        // Spawn in starting hearts
        spawnPrefabs();
        // Updates current state of the hearts
        updateHearts();
    }
    /// <summary>
    /// Spawns in the hearts
    /// </summary>
    public void spawnPrefabs()
    {
        //destroys all the children of the hearts container before spawning new ones to avoid duplicates.
        foreach (Transform child in heartsContainer)
            Destroy(child.gameObject);

        fullHearts = new GameObject[maxHp];
        emptyHearts = new GameObject[maxHp];

        int index = 0;
        // sets the number of rows needed to display all hearts based on the maxHp and heartsPerRow.
        int rows = (maxHp + heartsPerRow - 1) / heartsPerRow; 

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < heartsPerRow && index < maxHp; col++)
            {
                Vector3 pos = new Vector3(col * 1.75f, -row * 1.25f, 0f);
                //spawns the empty hearts prefab at the same position under the full colored heart.
                emptyHearts[index] = Instantiate(emptyHeartPrefab, heartsContainer);
                emptyHearts[index].transform.localPosition = pos;

                fullHearts[index] = Instantiate(heartPrefab, heartsContainer);
                fullHearts[index].transform.localPosition = pos;

                index++;
            }
        }
    }

    /// <summary>
    /// Updates the heart display based on the current HP. It sets the active state of the 
    /// full hearts based on the current HP and checks if the player is dead (HP <= 0) to 
    /// toggle the death panel and money text.
    /// </summary>
    public void updateHearts()
    {
        // Set all the hearts active
        for (int i = 0; i < fullHearts.Length; i++)
        {
            fullHearts[i].SetActive(i < hp);
        }
        // Check if player died
        if(hp <= 0)
        {
            // Destroy all the hearts
            foreach (Transform child in heartsContainer)
                Destroy(child.gameObject);
            // Enable dead
            isDead = true;
            // Enable end game
            gameManager.GetComponent<gameManager>().setGameState(true);
            // Toggles on the money text
            gameManager.GetComponent<moneyManager>().toggleMoneyText();
            // Displays the loss message on death screen
            gameManager.GetComponent<randomMessageManager>().displayLoseMessage();
            // Disables the round text
            gameManager.GetComponent<roundManager>().toggleRoundText();
            // Disables the round timer text
            gameManager.GetComponent<roundManager>().toggleTimerText();
            // Enables the death panel
            gameManager.GetComponent<playScenePanelManager>().toggleDeathPanel();

            // Displays how much money you had left
            deathPanelMoneyText.text = $"You Had ${gameManager.GetComponent<moneyManager>().getMoney() / 100f} left";
            Debug.Log("Player is dead!");
        }
    }

    /// <summary>
    /// Increases the maximum and current HP by one and updates the heart display.
    /// </summary>
    public void upgradeMaxHp()
    {
        maxHp++;
        hp++;
        // respawns the hearts
        spawnPrefabs();
        // updates the hearts
        updateHearts();
    }

    /// <summary>
    /// take 1 dmg and flashes the screen red if above certain Hp.
    /// </summary>
    public void takeDmg()
    {
        // Check if players hp is greater than 1 hp and player is not dead
        if (hp > 1 && getIsDead() == false)
        {

        }
        if (hp > 0)
        {
            StartCoroutine(dmgFlash());
            hp--;
        }
        updateHearts();
    }

    /// <summary>
    /// heal 1 hp
    /// </summary>
    public void heal()
    {
        if (hp < maxHp)
        {
            hp++;
        }
        updateHearts();
    }

    /// <summary>
    /// reset hp to max hp and updates the heart display.
    /// </summary>
    public void resetHp()
    {
        hp = maxHp;
        updateHearts();
    }

    /// <summary>
    /// Returns if the player is dead.
    /// </summary>
    /// <returns></returns>
    public bool getIsDead()
    {
        return isDead;
    }

    public int getCurrentHp()
    {
        return hp;
    }

    public int getMaxHp()
    {
        return maxHp;
    }

    private IEnumerator dmgFlash()
    {
        Color currentColor = new Color(1f, 1f, 1f, 1f);
        for (float num = 1f; num >= maxFlashColor.g; num -= 0.01f)
        {
            currentColor = new Color(1f, num, num, 1f);
            playerHit.color = currentColor;
            yield return new WaitForSeconds(maxFlashTime);
        }
        for (float num = maxFlashColor.g; num <= 1; num += 0.01f)
        {
            currentColor = new Color(1f, num, num, 1f);
            playerHit.color = currentColor;
            yield return new WaitForSeconds(minFlashTime);
        }
    }
}


