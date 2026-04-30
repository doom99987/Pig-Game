/****************************************************************************
* Name: enemyHp.cs
* Author: Caleb Bohm
* DigiPen Email: caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: Sets and manages the enemy's current Hp
*
****************************************************************************/

using UnityEngine;

public class enemyHp : MonoBehaviour
{
    private GameObject gameManager;
    [Header("HP Settings")]
    [Tooltip("Current HP of the enemy.")]
    [SerializeField] private int hp = 1;

    [Header("Money Settings")]
    [Tooltip("The amount of money given to the player when the enemy dies.")]
    [SerializeField] protected int moneyOnDeath = 0;
    [Tooltip("The multiplier used to calculate the money given to the player when the enemy dies.")]
    [SerializeField] protected int multiplier = 5;
    [SerializeField] private float[] money;
    [SerializeField] private int[] bulletUpgradeBonus;
    [SerializeField] private int bulletUpgradeBonusAmount;
    [SerializeField] private int bulletUpgradeCount;
    [SerializeField] private ParticleSystem particle;

    // Ran before update and only once
    public void Start()
    {
        gameManager = GameObject.Find("gameManager");
        bulletUpgradeCount = gameManager.GetComponent<shopManager>().getBulletUpgradeCount();
        int round = gameManager.GetComponent<roundManager>().getRound();
        hp = round += hp;
        moneyOnDeath = (int)money[round];
        bulletUpgradeBonusAmount = bulletUpgradeBonus[bulletUpgradeCount];
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
            Instantiate(particle, transform.position, Quaternion.identity);
        }
        if (hp <= 0)
        {
            giveMoneyOnDeath();
            gameManager.GetComponent<audioManager>().playEnemyDeathSound();
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// getter for the enemy hp
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
        gameManager.GetComponent<moneyManager>().addMoney(bulletUpgradeBonusAmount);
    }

}
