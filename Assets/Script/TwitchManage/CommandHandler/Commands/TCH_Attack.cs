using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Twitch/Command/Attack")]
public class TCH_Attack : TwitchCommandHandler
{
    public override void HandleCommand(MessageData data)
    {
        RoundCommandHistory.Instance.AddCommand(data.Author, _commandExecuted);
    }
}
