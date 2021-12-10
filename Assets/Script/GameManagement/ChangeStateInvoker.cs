using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Events/GameState/Invoker")]
public class ChangeStateInvoker : ScriptableObject
{
    public void ChangeState(GameState newState)
    {
        Debug.Log($"Load State {newState.StatesName.ToString()}");
        GameStateManager.Instance.ChangeState(newState);
    }
}
