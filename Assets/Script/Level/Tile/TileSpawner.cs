using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MyMonoBehaviour
{
    public GameObject TilePrefab;
    public Tiles Tiles;
    public MapConfiguration MapConfiguration;
    void Start()
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

    public void SpawnTile(Vector2 Position)
    {
        if (!TilePrefab) return;
        GameObject Tile = Instantiate(TilePrefab, new Vector3(Position.x, Position.y, 0), Quaternion.identity);
    }
}
