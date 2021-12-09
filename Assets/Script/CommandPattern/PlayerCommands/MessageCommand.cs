using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Test class to delet
 */

[CreateAssetMenu (menuName = "GameCommand/Message")]
public class MessageCommand : Command
{
    public MessageData PlayerData;

    public override void Execute(string playerName)
    {
        TwitchChatConnected.Instance.WriteMessage($"{playerName} : {PlayerData.Message}");
    }
}
