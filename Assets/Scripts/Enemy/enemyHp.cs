using System.Collections.ObjectModel;
using TMPro;
using UnityEngine;

public class enemyHp : MonoBehaviour
{
    protected GameObject gameManager;
    [Header("HP Settings")]
    [Tooltip("Current HP of the enemy.")]
    [SerializeField] protected int hp = 1;
    [Tooltip("Money give to player on enemy kill (5 = $0.05)")]
    [SerializeField] protected int moneyOnDeath = 0;
    [SerializeField] protected int mulitplier = 5;
    [SerializeField] protected float[] money = {5, 10 , 25, 35};
    
    public void Start()
    {
        gameManager = GameObject.Find("gameManager");
        int round = gameManager.GetComponent<roundManager>().getRound();
        hp = round += hp;
        moneyOnDeath = (int)money[round];
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
        if (hp >= 1)
        {
            hp -= dmg;
        }
        if (hp <= 0)
        {
            giveMoneyOnDeath();
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int getEnemyHp()
    {
        return hp;
    }

    /// <summary>
    /// gives money to the player once the enemy die.
    /// The amount of money given is determined by the moneyOnDeath variable.
    /// </summary>
    public void giveMoneyOnDeath()
    {
        gameManager.GetComponent<moneyManager>().addMoney(moneyOnDeath);
    }
}
