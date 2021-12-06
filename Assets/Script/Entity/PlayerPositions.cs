using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerPositions")]
public class PlayerPositions : ScriptableObject
{
    public GameEvent PlayerPositionChanged;
    [SerializeField]
    private List<Vector2> _positions;

    public void SetPosition(int PlayerIndex, Vector2 Position)
    {
        _positions[PlayerIndex] = Position;
        PlayerPositionChanged.Raise();
    }

    public void AddPosition(int PlayerIndex, Vector2 Position)
    {
        _positions[PlayerIndex] += Position;
        PlayerPositionChanged.Raise();
    }

    public void AddNewPosition(Vector2 Position)
    {
        _positions.Add(Position);
        PlayerPositionChanged.Raise();
    }

    public Vector2 GetPosition(int PlayerIndex)
    {
        return _positions[PlayerIndex];
    }
}