using UnityEngine;
using TMPro;

public class roundManager : MonoBehaviour
{
    protected float elapsedTime;        

    [Header("Round")]
    [SerializeField] protected int round = 0;
    [SerializeField] protected int totalRounds = 0;
    [SerializeField] protected float roundTime = 120f;
    [Header("Text Timer")]
    [SerializeField] TextMeshProUGUI timerText; 

    // Run is called before any update is called the first time
    private void Start()
    {
        elapsedTime = roundTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the game is paused
        if (!gameObject.GetComponent<gameManager>().getGameState())
        {
            // Updates the total time thats passed
            elapsedTime -= Time.deltaTime;

            // Displays the Time in 0:00 format
            int minutes = Mathf.FloorToInt((elapsedTime) / 60);
            int seconds = Mathf.FloorToInt((elapsedTime) % 60);
            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            // Checks if the round needs to be ended
            if (roundTime < 1)
            {
                gameObject.GetComponent<gameManager>().setRoundClear(true);
                gameObject.GetComponent<gameManager>().roundEnded();
                resetTimer();
                round++;
            }
        }
    }
    /// <summary>
    /// resets the Timer
    /// </summary>
    public void resetTimer()
    {
        elapsedTime = roundTime;
    }
}

