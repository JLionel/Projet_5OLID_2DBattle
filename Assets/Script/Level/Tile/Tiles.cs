using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/Tiles")]
public class Tiles : TilesData
{
    public List<Vector2> TileList = new List<Vector2>();

    public override void Init()
    {
        TileList = new List<Vector2>();
    }

    public override void AddNew(Vector2 Position)
    {
        TileList.Add(Position);
    }

    public bool Exists(Vector2 Position)
    {
        return TileList.Contains(Position);
    }
}
