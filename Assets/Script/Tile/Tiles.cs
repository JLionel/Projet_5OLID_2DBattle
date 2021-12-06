using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/Tiles")]
public class Tiles : ScriptableObject
{
    public Dictionary<Vector2, GameObject> TileList = new Dictionary<Vector2, GameObject>();

    public bool Exists(Vector2 Position)
    {
        return TileList.ContainsKey(Position);
    }
}
