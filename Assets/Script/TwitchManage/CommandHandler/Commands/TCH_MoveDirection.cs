using System.Collections;
using System.Collections.Generic;
using System.Data;
using Script.CommandPattern;
using UnityEngine;

[CreateAssetMenu (menuName = "Twitch/Command/Move")]
public class TCH_MoveDirection : TwitchCommandHandler
{
    public DirectionMove direction;
    
    public override void HandleCommand(MessageData data)
    {
        Vector2 movement = Vector2.zero;
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

        Command command = new MoveCommand(GetPlayer(data.Author), movement);
    }

    private PlayerMove GetPlayer(string pseudo)
    {
        //TODO temporaire
        return new PlayerMove();
    }
}
