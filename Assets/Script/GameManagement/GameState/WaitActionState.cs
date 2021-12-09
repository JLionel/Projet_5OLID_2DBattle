using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaitActionState : GameState
{
    private float _waitTimer;

    private float counter;
    
    //Todo set a timer
    public WaitActionState(GameStateManager gameStateManager, float waitTimer) : base(gameStateManager)
    {
        _statesName = StatesName.WaitTurnActions;
        _waitTimer = waitTimer;
        counter = 0;
    }

    public override void Tick()
    {
        counter += Time.deltaTime;
        if (counter >= _waitTimer)
        {
            GameStateManager.ChangeState(new ExecuteRoundState(GameStateManager));
        }
    }
    
    public override void OnStateEnter()
    {
        TwitchChatConnected.Instance.WriteMessage("Enter your three actions !!!! Move with !z, !q, !s, !d, or attack with !e. You can combine those command up to three like !zqd");
    }
}
