using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "GameCommand/PlayerCommand/JoinGame")]
public class JoinPlayerCommand : PlayerCommand
{
    [SerializeField] private PlayerNames playerList;
    
    //todo check if player not already in
    public override void Execute(string playerName)
    {
        if(gameStateName.Value == StatesName.JoinLobby)
        {
            if(!playerList.Contains(playerName))
            {
                playerList.AddNew(playerName);
                TwitchChatConnected.Instance.WriteMessage($"{playerName} joined");
            }
        }
    }
}
