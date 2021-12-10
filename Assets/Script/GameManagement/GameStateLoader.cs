using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateLoader : MonoBehaviour
{
    [SerializeField] private List<GameState> GameStatesLoaded;

    
    void OnEnable()
    {
        Debug.Log("CALLEEEEEEEEEEEEEEEEED");
        foreach (var gameState in GameStatesLoaded)
        {
            gameState.SetGameStateManager = GameStateManager.Instance;
        }
    }
    
    void OnDisable()
    {
        foreach (var gameState in GameStatesLoaded)
        {
            gameState.SetGameStateManager = null;
        }
    }
}
