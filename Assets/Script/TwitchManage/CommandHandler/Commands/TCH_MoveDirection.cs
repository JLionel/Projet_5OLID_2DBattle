using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Twitch/Command/Move")]
public class TCH_MoveDirection : TwitchCommandHandler
{
    public DirectionMove direction;
    
    public override void HandleCommand(MessageData data)
    {
        throw new System.NotImplementedException();
    }
}
