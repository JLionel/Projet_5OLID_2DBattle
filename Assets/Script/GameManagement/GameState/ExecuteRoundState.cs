using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "GameManagement/GameState/ExecuteRoundState")]
public class ExecuteRoundState : GameState
{
    private bool _endRound => RoundCommandHistory.Instance.endRound;
    
    //Todo check when all turned have been executed -> waitaction if no winner / -> endgame if winner
    public override void Tick()
    {
        if(_endRound)
            DefaultNextState.Raise();
    }
 
    public override void OnStateEnter()
    {
        TwitchChatConnected.Instance.WriteMessage("Time for battle SMOrc !!!");
        RoundCommandHistory.Instance.ExecuteRound();
    }
}
