using System;
using TMPro;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    int count = 0;
    [Header("References")]
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI buySpeedText;
    [SerializeField] float[] speedCost = { 5, 50, 500, 5000 };
    public void buySpeed()
    {
                if (gameManager.GetComponent<moneyManager>().getMoney() >= speedCost[count])
                {
                    player.GetComponent<PlayerMovement>().setCurSpeed(player.GetComponent<PlayerMovement>().getCurrentSpeed() + 1);
                    gameManager.GetComponent<moneyManager>().removeMoney(speedCost[count]);
                    buySpeedText.text = $"Buy ${speedCost[count + 1] / 100f}";
                    count++;
                }
    }
}
