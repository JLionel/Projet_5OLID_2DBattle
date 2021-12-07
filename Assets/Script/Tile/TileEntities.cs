using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/TileEntities")]
public class TileEntities : ScriptableObject
{
    public Dictionary<Vector2, GameObject> TileEntitiesList = new Dictionary<Vector2, GameObject>();

    public bool IsTileOccupied(Vector2 Position)
    {
        if (!TileEntitiesList.ContainsKey(Position)) return false;
        if (TileEntitiesList[Position]) { return true; }
        return false;
    }
}
