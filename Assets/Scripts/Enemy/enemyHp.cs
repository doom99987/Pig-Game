using TMPro;
using UnityEngine;

public class enemyHp : MonoBehaviour
{
    protected GameObject gameManager;
    [Header("HP Settings")]
    [Tooltip("Current HP of the enemy.")]
    [SerializeField] protected int hp = 1;
    [Tooltip("Maximum HP of the enemy. (Not Used)")]
    [SerializeField] protected int maxHp = 3;
    [Tooltip("Money give to player on enemy kill")]
    [SerializeField] protected int moneyOnDeath = 5;

    public void Start()
    {
        gameManager = GameObject.Find("gameManager");
    }
    /// <summary>
    /// take 1 dmg
    /// </summary>
    public void takeDmg()
    {
        if (hp > 1)
        {
            hp--;
        }
        else
        {
            giveMoneyOnDeath();
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// take dmg
    /// </summary>
    public void takeDmg(int dmg)
    {
        if (hp > 1)
        {
            hp -= dmg;
        }
        else
        {
            Destroy(gameObject);
        }
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
    }
    /// <summary>
    /// reset hp to max hp and updates the heart display.
    /// </summary>
    public void resetHp()
    {
        hp = maxHp;
    }

    public void giveMoneyOnDeath()
    {
        gameManager.GetComponent<moneyManager>().addMoney(moneyOnDeath);
    }
}
