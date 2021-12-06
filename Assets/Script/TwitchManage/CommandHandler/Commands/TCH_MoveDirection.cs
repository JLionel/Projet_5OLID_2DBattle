using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[CreateAssetMenu (menuName = "Twitch/Command/Move")]
public class TCH_MoveDirection : TwitchCommandHandler
{
    public DirectionMove direction;
    
    public override void HandleCommand(MessageData data)
    {
        Vector2 movement;
        switch (direction)
        {
            case DirectionMove.Up:
                movement = Vector2.up;
                break;
            case DirectionMove.Down:
                movement = Vector2.down;
                break;
            case DirectionMove.Left:
                movement = Vector2.left;
                break;
            case DirectionMove.Right:
                movement = Vector2.right;
                break;
        }
    }
}
