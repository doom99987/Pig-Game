using UnityEngine;
using TMPro;

public class roundManager : MonoBehaviour
{
    [Header("")]
    [SerializeField] protected float roundTime = 120f;
    [SerializeField] TextMeshProUGUI timerText;

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<gameManager>().getGameState())
        {
            roundTime -= Time.deltaTime;

            int minutes = Mathf.FloorToInt((roundTime) / 60);
            int seconds = Mathf.FloorToInt((roundTime) % 60);
            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            if (roundTime < 1)
            {
                gameObject.GetComponent<gameManager>().setGameClear(true);
            }
        }
    }
}

