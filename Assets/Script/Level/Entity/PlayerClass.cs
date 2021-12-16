using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerClass")]
public class PlayerClass : ScriptableObject
{
    public List<Vector2Int> MoveAttackLocalPos;
    public List<Vector2Int> AttackLocalPos;

    public List<Vector2Int> GetMoveAttackPos(Vector2Int position, Vector2Int direction)
    {
        List<Vector2Int> moveAttackGlobalPos = new List<Vector2Int>();
        for (int i = 0; i < MoveAttackLocalPos.Count; i++)
        {
            moveAttackGlobalPos.Add(position + RotateVector(MoveAttackLocalPos[i], direction));
        }
        return moveAttackGlobalPos;
    }

    public List<Vector2Int> GetSpecialAttackPos(Vector2Int position, Vector2Int direction)
    {
        List<Vector2Int> attackGlobalPos = new List<Vector2Int>();
        for (int i = 0; i < AttackLocalPos.Count; i++)
        {
            attackGlobalPos.Add(position + RotateVector(AttackLocalPos[i], direction));
        }
        return attackGlobalPos;
    }

    private Vector2Int RotateVector(Vector2Int vector, Vector2Int direction)
    {
        return new Vector2Int(direction.x * vector.x - direction.y * vector.y, direction.y * vector.x + direction.x * vector.y);
    }

}
