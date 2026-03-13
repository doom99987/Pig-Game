using TMPro;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    int count = 0;
    [Header("References")]
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI buySpeedText;

    public void buySpeed()
    {
        switch (count)
        {
            case 0:
                if (gameManager.GetComponent<moneyManager>().getMoney() >= 5)
                {
                    player.GetComponent<PlayerMovement>().setCurSpeed(player.GetComponent<PlayerMovement>().getCurrentSpeed() + 1);
                    gameManager.GetComponent<moneyManager>().removeMoney(5);
                    buySpeedText.text = "Buy 50";
                    count++;
                }
                break;
            case 1:
                 if (gameManager.GetComponent<moneyManager>().getMoney() >= 50)
                {
                    player.GetComponent<PlayerMovement>().setCurSpeed(player.GetComponent<PlayerMovement>().getCurrentSpeed() + 1);
                    gameManager.GetComponent<moneyManager>().removeMoney(10);
                    count++;
                }
                break;
            case 2:
                 if (gameManager.GetComponent<moneyManager>().getMoney() >= 500)
                {
                    player.GetComponent<PlayerMovement>().setCurSpeed(player.GetComponent<PlayerMovement>().getCurrentSpeed() + 1);
                    gameManager.GetComponent<moneyManager>().removeMoney(15);
                    count++;
                }
                break;
            case 3:
                if (gameManager.GetComponent<moneyManager>().getMoney() >= 5000)
                {
                    player.GetComponent<PlayerMovement>().setCurSpeed(player.GetComponent<PlayerMovement>().getCurrentSpeed() + 1);
                    gameManager.GetComponent<moneyManager>().removeMoney(20);
                    count++;
                }
                break;
        }
    }
}
