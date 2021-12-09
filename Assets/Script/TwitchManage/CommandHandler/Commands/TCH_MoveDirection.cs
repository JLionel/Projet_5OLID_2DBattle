using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Script.CommandPattern;
using UnityEngine;

[CreateAssetMenu (menuName = "Twitch/Command/Move")]
public class TCH_MoveDirection : TwitchCommandHandler
{
    public override void HandleCommand(MessageData data)
    {
        RoundCommandHistory.Instance.AddCommand(data.Author, _commandExecuted);
    }
}
