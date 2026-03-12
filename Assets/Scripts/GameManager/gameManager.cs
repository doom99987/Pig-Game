using UnityEngine;

public class gameManager : MonoBehaviour
{
    [Header("Game Pause")] 
    [SerializeField] protected bool gamePaused;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getGamePaused()
    {
        return gamePaused;
    }

    public void setGamePaused(bool gameState)
    {
        gamePaused = gameState;
    }
}
