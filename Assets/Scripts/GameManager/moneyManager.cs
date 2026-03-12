using UnityEngine;

public class moneyManager : MonoBehaviour
{
    [Header("Money")]
    [SerializeField] float money = 25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addMoney(float amount)
    {
        money += amount;
    }

    public void removeMoney(float amount) {
        money -= amount;
    }
}
