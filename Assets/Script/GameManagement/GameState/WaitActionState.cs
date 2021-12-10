using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "GameManagement/GameState/WaitActionState")]
public class WaitActionState : GameState
{
    [SerializeField] private FloatVariable _waitTimer;

    private float _saveWaitTimer;
    
    public override void Tick()
    {
        _waitTimer.Value -= Time.deltaTime;
        if (_waitTimer.Value <= 0)
        {
            DefaultNextState.Raise();
        }
    }
    
    public override void OnStateEnter()
    {
        _saveWaitTimer = _waitTimer.Value;
        TwitchChatConnected.Instance.WriteMessage("Enter your three actions !!!! Move with !z, !q, !s, !d, or attack with !e. You can combine those command up to three like !zqd");
    }

    public override void OnStateExit()
    {
        _waitTimer.Value = _saveWaitTimer;
    }
}
