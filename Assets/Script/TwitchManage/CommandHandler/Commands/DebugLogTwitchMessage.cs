using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TwitchChatConnected;


/*
 * Test class to delet
 */
[CreateAssetMenu(menuName = "Twitch/Command/DisplayMessage")]
public class DebugLogTwitchMessage : TwitchCommandHandler
{
    public override void HandleCommand(MessageData data)
    {
        Debug.Log($"{data.Author} : {data.Message}");
        var commandCast = (MessagePlayerCommand)playerCommandExecuted;
        commandCast.PlayerData = data;
        commandCast.Execute(data.Author);
    }
} 

