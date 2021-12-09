using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndGameState : GameState
{
    public EndGameState(GameStateManager gameStateManager) : base(gameStateManager)
    {
        _statesName = StatesName.EndGame;
    }

    public override void Tick()
    {
        
    }
}
