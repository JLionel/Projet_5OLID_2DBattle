using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Twitch/Command/DisplayMessage")]
public class DebugLogTwitchMessage : TwitchCommandHandler
{
    public override void HandleCommand(MessageData data)
    {
        Debug.Log($"{data.Author} : {data.Message}");
        TwitchChatConnected.Instance().WriteMessage($"{data.Author} a dit {data.Message.Substring("!message".Length)}");
    }
} 
