using UnityEngine;

public class gameManager : MonoBehaviour
{
    [Header("Game States")] 
    [SerializeField] protected bool gamePaused;
    [SerializeField] protected bool roundClear;
    /// <summary>
    /// Tells you if the game is paused
    /// </summary>
    /// <returns></returns>
    public bool getGameState()
    {
        return gamePaused;
    }
    /// <summary>
    /// Tells you if you cleared a round
    /// </summary>
    /// <returns></returns>
    public bool getRoundClear()
    {
        return roundClear;
    }
    /// <summary>
    /// Called to set if the game is paused
    /// </summary>
    /// <param name="gameState"></param>
    public void setGameState(bool gameState)
    {
        gamePaused = gameState;
    }
    /// <summary>
    /// Called to set if the round is cleared and pauses the game
    /// </summary>
    /// <param name="gameState"></param>
    public void setRoundClear(bool gameState)
    {
        roundClear = gameState;
        gamePaused = gameState;
    }

    public void FixedUpdate()
    {
        if (roundClear)
        {
            gameObject.GetComponent<playScenePanelManager>().toggleShopPanel();
        }
    }
}

