using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatesName
{
    Default,
    JoinLobby,
    WaitTurnActions,
    ExecuteRound,
    EndGame,
}

public abstract class GameState : ScriptableObject
{
    [SerializeField] protected StatesName _statesName;
    public StatesName StatesName => _statesName;

    protected GameStateManager GameStateManager;

    public GameStateEvent DefaultNextState;
    
    public GameStateManager SetGameStateManager
    {
        set => GameStateManager = value;
    }

    public virtual void OnStateEnter(){}
    public virtual void OnStateExit(){}
    
    public abstract void Tick();
}
