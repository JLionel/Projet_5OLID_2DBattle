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
    Fade,
}

public abstract class GameState : ScriptableObject
{
    [SerializeField] protected StatesName statesName;
    public StatesName StatesName => statesName;

    public GameStateEvent DefaultNextState;
    

    public virtual void OnStateEnter(){}
    public virtual void OnStateExit(){}
    
    public abstract void Tick();
}
