using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Twitch/Command/JoinGame")]
public class TCH_JoinGame : TwitchCommandHandler
{
    //Todo check if in join state
    public override void HandleCommand(MessageData data)
    {
        playerCommandExecuted.Execute(data.Author);
    }
}
