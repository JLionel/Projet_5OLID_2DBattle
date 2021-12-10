using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Test class to delet
 */

[CreateAssetMenu (menuName = "GameCommand/PlayerCommand/Message")]
public class MessagePlayerCommand : PlayerCommand
{
    public MessageData PlayerData;

    public override void Execute(string playerName)
    {
        TwitchChatConnected.Instance.WriteMessage($"{playerName} : {PlayerData.Message}");
    }
}
