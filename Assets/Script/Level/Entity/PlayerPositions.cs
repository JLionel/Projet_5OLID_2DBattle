using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerPositions")]
public class PlayerPositions : PlayerData
{
    public GameEvent PlayerPositionChanged;
    [SerializeField]
    private List<Vector2Int> _positions = new List<Vector2Int>();

    public override void Init()
    {
        _positions = new List<Vector2Int>();
    }

    public override void AddNew()
    {
        _positions.Add(Vector2Int.zero);
    }

    public override void Remove(int Index)
    {
        _positions.RemoveAt(Index);
    }

    public void SetPosition(int PlayerIndex, Vector2Int Position)
    {
        if (!PlayerPositionChanged) { return; }
        _positions[PlayerIndex] = Position;
        PlayerPositionChanged.Raise();
    }

    public void AddPosition(int PlayerIndex, Vector2Int Position)
    {
        if (!PlayerPositionChanged) { return; }
        _positions[PlayerIndex] += Position;
        PlayerPositionChanged.Raise();
    }

    public Vector2Int GetPosition(int PlayerIndex)
    {
        if (_positions.Count <= PlayerIndex) { return Vector2Int.zero; }
        return _positions[PlayerIndex];
    }

    public int GetPlayerCount()
    {
        return _positions.Count;
    }
}