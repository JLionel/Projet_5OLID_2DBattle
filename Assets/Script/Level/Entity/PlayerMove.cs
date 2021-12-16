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
    public TileEvent AttackOnTile;

    public GameEvent OnWait;

    public override void DoAwake()
    {

    }
    public override void DoUpdate()
    {
    }

    public void MoveInDirection(Vector2Int direction)
    {
        if (!(direction.magnitude == 1 && (direction.x == 0 || direction.y == 0))) return;
        if (!PlayerIndexManager) return;

        Vector2Int position = PlayerPositions.GetPosition(PlayerIndexManager.Index);
        Vector2Int newPosition = position + direction;

        if (PlayerDirections)
        {
            PlayerDirections.Directions[PlayerIndexManager.Index] = direction;
        }

        Vector2Int AttackPos = MoveFromTo(position, newPosition) ? newPosition : position;

        MoveAttack(PlayerIndexManager.Index, AttackPos, direction);
    }
    public void MoveTo(Vector2Int newPosition)
    {
        if (!PlayerIndexManager) return;

        Vector2Int position = PlayerPositions.GetPosition(PlayerIndexManager.Index);

        MoveFromTo(position, newPosition);
    }
    private bool MoveFromTo(Vector2Int position, Vector2Int newPosition)
    {
        if (!Tiles.Exists(newPosition)) return false;
        if (TileEntities.TilePlayer(newPosition) != -1) return false;

        LeaveTile(position);
        JoinTile(newPosition);
        PlayerPositions.SetPosition(PlayerIndexManager.Index, newPosition);
        return true;
    }
    private void LeaveTile(Vector2Int position)
    {
        if (TileEntities.GetEntity(position) == Entity) { TileEntities.SetEntity(position, null); }
    }
    private void JoinTile(Vector2Int position)
    {
        TileEntities.SetEntity(position, Entity);
    }

    private void MoveAttack(int index, Vector2Int position, Vector2Int direction)
    {
        List<Vector2Int> moveAttackPos = PlayerClasses.PlayerClassesList[index].GetMoveAttackPos(position, direction);

        Vector2Int moveAttackPo;
        int tilePlayer;
        for (int i = 0; i < moveAttackPos.Count; i++)
        {
            moveAttackPo = moveAttackPos[i];
            if (Tiles.Exists(moveAttackPo))
            {
                tilePlayer = TileEntities.TilePlayer(moveAttackPo);
                if (tilePlayer != -1)
                {
                    Debug.Log(index + " attacked " + tilePlayer + " from " + position + " to " + moveAttackPo);
                    PlayerHealth.DecreaseHealth(tilePlayer);
                }
                if (!AttackOnTile) { return; }
                AttackOnTile.Raise(moveAttackPo);
            }
        }
    }
}
