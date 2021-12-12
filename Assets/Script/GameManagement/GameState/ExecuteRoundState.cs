using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "GameManagement/GameState/ExecuteRoundState")]
public class ExecuteRoundState : GameState
{
    [SerializeField] private BoolVariable _endRound;
    [SerializeField] private PlayerNames playerList;
    [SerializeField] private GameStateEvent EndGameState;
    
    //Todo check when all turned have been executed -> waitaction if no winner / -> endgame if winner
    public override void Tick()
    {
        if(_endRound.Value)
        {
            if (playerList.Names.Count == 1)
            {
                EndGameState.Raise();
            }else
            {
                DefaultNextState.Raise();
            }
        }
    }
 
    public override void OnStateEnter()
    {
        TwitchChatConnected.Instance.WriteMessage("Time for battle SMOrc !!!");
        RoundCommandHistory.Instance.ExecuteRound();
    }
}
