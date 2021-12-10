using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "GameCommand/PlayerCommand/JoinGame")]
public class JoinPlayerCommand : PlayerCommand
{
    //todo check if player not already in
    public override void Execute(string playerName)
    {
        if(GameStateManager.Instance.GameState.StatesName == StatesName.JoinLobby)
            TwitchChatConnected.Instance.WriteMessage($"{playerName} joined");
    }
}
