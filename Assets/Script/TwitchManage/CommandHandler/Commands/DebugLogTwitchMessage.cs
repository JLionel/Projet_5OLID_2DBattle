using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TwitchChatConnected;

[CreateAssetMenu(menuName = "Twitch/Command/DisplayMessage")]
public class DebugLogTwitchMessage : TwitchCommandHandler
{
    public override void HandleCommand(MessageData data)
    {
        Debug.Log($"{data.Author} : {data.Message}");
        RoundCommandHistory.Instance.AddCommand(data.Author, new MessageCommand(data));
    }
} 

