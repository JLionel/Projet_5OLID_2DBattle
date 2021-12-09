using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JoinLobbyState : GameState
{
    public JoinLobbyState(GameStateManager gameStateManager) : base(gameStateManager)
    {
        _statesName = StatesName.JoinLobby;
    }

    public override void Tick()
    {
        
    }

    public override void OnStateEnter()
    {
        TwitchChatConnected.Instance.WriteMessage("Time to start PogChamp : to join the game tap !join in the chat");
    }
}
