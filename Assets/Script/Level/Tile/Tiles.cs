using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/Tiles")]
public class Tiles : TileData
{
    public List<Vector2Int> TileList = new List<Vector2Int>();

    public override void Init()
    {
        TileList = new List<Vector2Int>();
    }

    public override void AddNew(Vector2Int position)
    {
        TileList.Add(position);
    }

    public bool Exists(Vector2Int position)
    {
        return TileList.Contains(position);
    }
}
