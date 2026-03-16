using UnityEngine;
public class HpManager : MonoBehaviour
{
    [SerializeField] protected int hp = 3;
    [SerializeField] protected int maxHp = 5;
    [SerializeField] protected int heartsPerRow = 4;
    [SerializeField] GameObject heartPrefab;
    [SerializeField] GameObject emptyHeartPrefab;
    [SerializeField] Transform heartsContainer;

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
        foreach (Transform child in heartsContainer)
            Destroy(child.gameObject);

        fullHearts = new GameObject[maxHp];
        emptyHearts = new GameObject[maxHp];
        
        int index = 0;
        int rows = (maxHp + heartsPerRow - 1) / heartsPerRow;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < heartsPerRow && index < maxHp; col++)
            {
                Vector3 pos = new Vector3(col * 1.25f, -row * 1.25f, 0f);

                emptyHearts[index] = Instantiate(emptyHeartPrefab, heartsContainer);
                emptyHearts[index].transform.localPosition = pos;

                fullHearts[index] = Instantiate(heartPrefab, heartsContainer);
                fullHearts[index].transform.localPosition = pos;

                index++;
            }
        }
    }

    public void updateHearts()
    {
        for (int i = 0; i < fullHearts.Length; i++)
        {
            fullHearts[i].SetActive(i < hp);
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
    public void reseHp()
    {
        hp = maxHp;
        updateHearts();
    }
}


