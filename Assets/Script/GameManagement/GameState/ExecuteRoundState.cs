using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExecuteRoundState : GameState
{
    private bool _endRound => RoundCommandHistory.Instance.endRound;
    
    public ExecuteRoundState(GameStateManager gameStateManager) : base(gameStateManager)
    {
        _statesName = StatesName.ExecuteRound;
    }

    //Todo check when all turned have been executed -> waitaction if no winner / -> endgame if winner
    public override void Tick()
    {
        if(_endRound)
            GameStateManager.ChangeState(new WaitActionState(GameStateManager, RoundCommandHistory.Instance.EnterActionTimer.Value));
    }
 
    public override void OnStateEnter()
    {
        TwitchChatConnected.Instance.WriteMessage("Time for battle SMOrc !!!");
        RoundCommandHistory.Instance.ExecuteRound();
    }
}
