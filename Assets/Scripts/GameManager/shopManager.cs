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
   public enum UpgradeType
    {
        Speed,
        Hp,
        healing,
        Pierce
    }
    [SerializeField] float[] speedCost = { 5, 50, 500, 5000 };
    [SerializeField]
    //public void buyUpgrade(UpgradeType type)
    //{
    //    switch (type)
    //    {
    //        case UpgradeType.Speed:
    //            buySpeed();
    //            break;
    //        case UpgradeType.Hp:
    //            break;
    //        case UpgradeType.healing:
    //            break;
    //        case UpgradeType.Pierce:
    //            break;
    //        default:
    //            throw new ArgumentOutOfRangeException(nameof(type), type, null);
    //    }
    //}
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
