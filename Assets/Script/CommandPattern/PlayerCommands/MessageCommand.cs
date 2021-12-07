using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCommand : Command
{
    private MessageData _playerData;

    public MessageCommand(MessageData data)
    {
        _playerData = data;
    }
    
    public override void Execute()
    {
        TwitchChatConnected.Instance.WriteMessage($"{_playerData.Author} : {_playerData.Message}");
    }
}
