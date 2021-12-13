using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : OrdonedMonoBehaviour
{
    public PlayerPositions PlayerPositions;
    public Tiles Tiles;
    public TileEntities TileEntities;
    public PlayerIndexManager PlayerIndexManager;
    public PlayerHealth PlayerHealth;
    public PlayerClasses PlayerClasses;
    public PlayerDirections PlayerDirections;
    public Entity Entity;

    public override void DoAwake()
    {

    }
    public override void DoUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveInDirection(new Vector2Int(1, 0));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveInDirection(new Vector2Int(-1, 0));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveInDirection(new Vector2Int(0, 1));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveInDirection(new Vector2Int(0, -1));
        }
    }

    public void MoveInDirection(Vector2Int Direction)
    {
        if (!(Direction.magnitude == 1 && (Direction.x == 0 || Direction.y == 0))) return;
        if (!PlayerIndexManager) return;

        Vector2Int Position = PlayerPositions.GetPosition(PlayerIndexManager.Index);
        Vector2Int NewPosition = Position + Direction;

        MoveFromTo(Position, NewPosition);
        if (PlayerDirections)
        {
            PlayerDirections.Directions[PlayerIndexManager.Index] = Direction;
        }
        MoveAttack(PlayerIndexManager.Index, NewPosition, Direction);
    }
    public void MoveTo(Vector2Int NewPosition)
    {
        if (!PlayerIndexManager) return;

        Vector2Int Position = PlayerPositions.GetPosition(PlayerIndexManager.Index);

        MoveFromTo(Position, NewPosition);
    }
    private void MoveFromTo(Vector2Int Position, Vector2Int NewPosition)
    {
        if (!Tiles.Exists(NewPosition)) return;
        if (TileEntities.TilePlayer(NewPosition) != -1) return;

        LeaveTile(Position);
        JoinTile(NewPosition);
        PlayerPositions.SetPosition(PlayerIndexManager.Index, NewPosition);
    }
    private void LeaveTile(Vector2Int Position)
    {
        if (TileEntities.GetEntity(Position) == Entity) { TileEntities.SetEntity(Position, null); }
    }
    private void JoinTile(Vector2Int Position)
    {
        TileEntities.SetEntity(Position, Entity);
    }

    private void MoveAttack(int Index, Vector2Int Position, Vector2Int Direction)
    {
        List<Vector2Int> MoveAttackPos = PlayerClasses.PlayerClassesList[Index].GetMoveAttackPos(Position, Direction);

        Vector2Int AttackPos;
        int TilePlayer;
        for (int i = 0; i < MoveAttackPos.Count; i++)
        {
            AttackPos = MoveAttackPos[i];
            if (Tiles.Exists(AttackPos))
            {
                TilePlayer = TileEntities.TilePlayer(AttackPos);
                if (TilePlayer != -1)
                {
                    PlayerHealth.DecreaseHealth(TilePlayer);
                }
            }
        }
    }
}
