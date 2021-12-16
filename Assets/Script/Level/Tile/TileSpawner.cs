using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : OrdonedMonoBehaviour
{
    public GameObject TilePrefab;
    public MapConfiguration MapConfiguration;
    public TileEvent AddedNewTile;

    public override void DoAwake()
    {
        if (MapConfiguration)
        {
            for (int i = 0; i < MapConfiguration.TilePositions.Count; i++)
            {
                SpawnTile(MapConfiguration.TilePositions[i]);
            }
        }
    }
    public override void DoUpdate()
    {

    }

    public void SpawnTile(Vector2Int position)
    {
        if (!TilePrefab) return;
        GameObject tile = Instantiate(TilePrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
        AddedNewTile.Raise(position);
    }
}
