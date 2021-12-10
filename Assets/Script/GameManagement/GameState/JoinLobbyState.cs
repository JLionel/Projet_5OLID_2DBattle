using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "GameManagement/GameState/JoinLobbyState")]
public class JoinLobbyState : GameState
{
    public override void Tick()
    {
        
    }

    public override void OnStateEnter()
    {
        TwitchChatConnected.Instance.WriteMessage("Time to start PogChamp : to join the game tap !join in the chat");
    }
}
