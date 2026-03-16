using System;
using TMPro;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    protected int sCount = 0;
    protected int hCount = 0;
    protected int healingCount = 0;
    protected int pierceCount = 0;
    [Header("References")]
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI buySpeedText;
    [SerializeField] float[] speedCost = { 5, 50, 500, 5000 };
    [SerializeField] float[] hpCost = { 5, 50, 500, 5000 };
    [SerializeField] float[] healingCost = { 5, 50, 500, 5000 };
    [SerializeField] float[] pierceCost = { 5, 50, 500, 5000 };
    public void buySpeed()
    {
                if (gameManager.GetComponent<moneyManager>().getMoney() >= speedCost[sCount])
                {
                    player.GetComponent<PlayerMovement>().setCurSpeed(player.GetComponent<PlayerMovement>().getCurrentSpeed() + 1);
                    gameManager.GetComponent<moneyManager>().removeMoney(speedCost[sCount]);
                    buySpeedText.text = $"Buy ${speedCost[sCount + 1] / 100f}";
                    sCount++;
                }
    }

    public void buyHp()
    {
        if (gameManager.GetComponent<moneyManager>().getMoney() >= hpCost[hCount])
        {
            gameManager.GetComponent<HpManager>().upgradeMaxHp();
            gameManager.GetComponent<moneyManager>().removeMoney(hpCost[hCount]);
            buySpeedText.text = $"Buy ${hpCost[hCount + 1] / 100f}";
            hCount++;
        }
    }
    public void buyHealing()
    {
        if (gameManager.GetComponent<moneyManager>().getMoney() >= healingCost[healingCount])
        {
            player.GetComponent<PlayerMovement>().setCurSpeed(player.GetComponent<PlayerMovement>().getCurrentSpeed() + 1);
            gameManager.GetComponent<moneyManager>().removeMoney(healingCost[healingCount]);
            buySpeedText.text = $"Buy ${healingCost[healingCount + 1] / 100f}";
            healingCount++;
        }
    }
    public void buyPierce()
    {
        if (gameManager.GetComponent<moneyManager>().getMoney() >= pierceCost[pierceCount])
        {
            player.GetComponent<PlayerMovement>().setCurSpeed(player.GetComponent<PlayerMovement>().getCurrentSpeed() + 1);
            gameManager.GetComponent<moneyManager>().removeMoney(pierceCost[pierceCount]);
            buySpeedText.text = $"Buy ${pierceCost[pierceCount + 1] / 100f}";
            pierceCount++;
        }
    }
}
