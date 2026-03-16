using UnityEngine;

public class gameManager : MonoBehaviour
{
    [Header("Game States")] 
    [SerializeField] protected bool gamePaused;
    [SerializeField] protected bool gameClear;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool getGameState()
    {
        return gamePaused;
    }

    public bool getGameClear()
    {
        return gameClear;
    }

    public void setGameState(bool gameState)
    {
        gamePaused = gameState;
    }
    
    public void setGameClear(bool gameState)
    {
        gameClear = gameState;
        gamePaused = gameState;
    }
}
