using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTileSOUpdater : MonoBehaviour
{
    public List<TileData> TileDataToUpdate;

    public void OnNewTileAdded(Vector2Int position)
    {
        foreach (var tileData in TileDataToUpdate)
        {
            tileData.AddNew(position);
        }
    }
}