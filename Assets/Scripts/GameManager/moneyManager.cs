using TMPro;
using UnityEngine;

public class moneyManager : MonoBehaviour
{
    [Header("Money")]
    [SerializeField] float money = 2500f;
    [SerializeField] TextMeshProUGUI moneyText;

    /// <summary>
    /// updates money. 
    /// </summary>
    void Update()
    {
        moneyText.text = $"${money/100f}";
    }

    public void addMoney(float amount)
    {
        money += amount;
    }

    public void removeMoney(float amount) {
        money -= amount;
    }

    public float getMoney()
    {
        return money; 
    }
}
