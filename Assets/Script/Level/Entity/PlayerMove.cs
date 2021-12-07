using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MyMonoBehaviour
{
    public PlayerPositions PlayerPositions;
    public Tiles Tiles;
    public TileEntities TileEntities;
    public PlayerIndexManager PlayerIndexManager;
    public Entity Entity;

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

    private void Move(Vector2 Direction)
    {
        if (!(Direction.magnitude == 1 && (Direction.x == 0 || Direction.y == 0))) return;
        if (!PlayerIndexManager) return;
        if (PlayerIndexManager.Index == 0) return;

        Vector2 Position = PlayerPositions.GetPosition(PlayerIndexManager.Index);
        Vector2 NewPosition = Position + Direction;

        if (!Tiles.Exists(NewPosition)) return;
        if (!TileEntities.IsTileFree(NewPosition)) return;

        LeaveTile(Position);
        JoinTile(NewPosition);
        PlayerPositions.SetPosition(PlayerIndexManager.Index, NewPosition);
    }

    private void LeaveTile(Vector2 Position)
    {
        TileEntities.SetEntity(Position, null);
    }
    private void JoinTile(Vector2 Position)
    {
        TileEntities.SetEntity(Position, Entity);
    }
}