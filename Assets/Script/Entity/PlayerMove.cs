using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MyMonoBehaviour
{
    public PlayerPosition PlayerPosition;
    public Tiles Tiles;
    public TileEntities TileEntities; 
    public override void DoStart()
    {

    }
    public override void DoUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(new Vector2(1, 0));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(new Vector2(-1, 0));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(new Vector2(0, 1));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(new Vector2(0, -1));
        }
    }

    public void Move(Vector2 Direction)
    {
        if (Direction.magnitude != 1 || !(Direction.x == -1 || Direction.x == 0 || Direction.x == 1) || !(Direction.y == -1 || Direction.y == 0 || Direction.y == 1)) return;
        Vector2 Position = PlayerPosition.GetValue();
        Vector2 NewPosition = Position + Direction;

        if (!Tiles.Exists(NewPosition)) return;
        if (TileEntities.IsTileOccupied(NewPosition)) return;

        LeaveTile(Position);
        JoinTile(NewPosition);
        PlayerPosition.SetValue(NewPosition);
    }

    private void LeaveTile(Vector2 Position)
    {
        TileEntities.TileEntitiesList[Position] = null;
    }
    private void JoinTile(Vector2 Position)
    {
        TileEntities.TileEntitiesList[Position] = gameObject;
    }
}
