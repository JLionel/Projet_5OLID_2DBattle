using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatesName
{
    Navigation,
    JoinLobby,
    WaitTurnActions,
    ExecuteRound,
    EndGame,
}

public abstract class GameState
{
    protected StatesName _statesName;
    public StatesName StatesName => _statesName;

    protected GameStateManager GameStateManager;

    public GameState(GameStateManager gameStateManager)
    {
        GameStateManager = gameStateManager;
    }
    
    public virtual void OnStateEnter(){}
    public virtual void OnStateExit(){}
    
    public abstract void Tick();
}
