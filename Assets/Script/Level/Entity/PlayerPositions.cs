using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerPositions")]
public class PlayerPositions : LevelData
{
    public GameEvent PlayerPositionChanged;
    [SerializeField]
    private List<Vector2> _positions = new List<Vector2>();

    public override void Init()
    {
        _positions = new List<Vector2>();
    }

    public void SetPosition(int PlayerIndex, Vector2 Position)
    {
        if (!PlayerPositionChanged) { return; }
        _positions[PlayerIndex] = Position;
        PlayerPositionChanged.Raise();
    }

    public void AddPosition(int PlayerIndex, Vector2 Position)
    {
        if (!PlayerPositionChanged) { return; }
        _positions[PlayerIndex] += Position;
        PlayerPositionChanged.Raise();
    }

    public void AddNewPosition(Vector2 Position)
    {
        if (!PlayerPositionChanged) { return; }
        _positions.Add(Position);
        PlayerPositionChanged.Raise();
    }

    public Vector2 GetPosition(int PlayerIndex)
    {
        if (_positions.Count <= PlayerIndex) { return Vector2.zero; }
        return _positions[PlayerIndex];
    }
}