using TMPro;
using UnityEngine;

public class moneyManager : MonoBehaviour
{
    [Header("Money")]
    [SerializeField] float money = 25f;
    [SerializeField] TextMeshProUGUI moneyText;

    /// <summary>
    /// updates money. 
    /// </summary>
    void Update()
    {
        moneyText.text = $"${money}";
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
