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
using TMPro;
using UnityEngine;
public class HpManager : MonoBehaviour
{
    [Header("HP Settings")]
    [Tooltip("Current HP of the player.")]
    [SerializeField] protected int hp = 3;
    [Tooltip("Maximum HP of the player.")]
    [SerializeField] protected int maxHp = 3;
    [Tooltip("Number of hearts to display per row in the UI.")]
    [SerializeField] protected int heartsPerRow = 4;
    [Header("Prefabs, Containers and Refrences")]
    [SerializeField] GameObject heartPrefab;
    [SerializeField] GameObject emptyHeartPrefab;
    [SerializeField] Transform heartsContainer;
    [SerializeField] GameObject gameManager;
    [SerializeField] TextMeshProUGUI deathPanelMoneyText;

    GameObject[] fullHearts;
    GameObject[] emptyHearts;

    void Start()
    {
        spawnPrefabs();
        updateHearts();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) takeDmg();
        if (Input.GetKeyDown(KeyCode.H)) heal();
        if (Input.GetKeyDown(KeyCode.U)) upgradeMaxHp();
    }

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
                Vector3 pos = new Vector3(col * 1.25f, -row * 1.25f, 0f);
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
    /// updates the heart display based on the current HP. It sets the active state of the full hearts based on the current HP and checks if the player is dead (HP <= 0) to toggle the death panel and money text.
    /// </summary>
    public void updateHearts()
    {
        for (int i = 0; i < fullHearts.Length; i++)
        {
            fullHearts[i].SetActive(i < hp);
        }
        if(hp<= 0)
        {
            gameManager.GetComponent<gameManager>().setGameState(true);
            gameManager.GetComponent<moneyManager>().toggleMoneyText();
            gameManager.GetComponent<playScenePanelManager>().toggleDeathPanel();
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
        spawnPrefabs();
        updateHearts();
    }
    /// <summary>
    /// take 1 dmg
    /// </summary>
    public void takeDmg()
    {
        if (hp > 0)
        {
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
}


