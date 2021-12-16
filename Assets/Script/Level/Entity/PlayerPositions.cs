using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerPositions")]
public class PlayerPositions : PlayerData
{
    public GameEvent PlayerPositionChanged;
    [SerializeField]
    private List<Vector2Int> positions = new List<Vector2Int>();

    public override void Init()
    {
        positions = new List<Vector2Int>();
    }

    public override void AddNew()
    {
        positions.Add(Vector2Int.zero);
    }

    public override void Remove(int index)
    {
        positions.RemoveAt(index);
    }

    public void SetPosition(int playerIndex, Vector2Int position)
    {
        if (!PlayerPositionChanged) { return; }
        positions[playerIndex] = position;
        PlayerPositionChanged.Raise();
    }

    public void AddPosition(int playerIndex, Vector2Int position)
    {
        if (!PlayerPositionChanged) { return; }
        positions[playerIndex] += position;
        PlayerPositionChanged.Raise();
    }

    public Vector2Int GetPosition(int playerIndex)
    {
        if (positions.Count <= playerIndex) { return Vector2Int.zero; }
        return positions[playerIndex];
    }

    public int GetPlayerCount()
    {
        return positions.Count;
    }

    public void SetPositionList(List<Vector2Int> newPositionList)
    {
        positions = newPositionList;
    }

    public List<Vector2Int> GetPositionList()
    {
        return positions;
    }
}