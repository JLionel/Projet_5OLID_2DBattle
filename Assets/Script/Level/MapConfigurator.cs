using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConfigurator : OrdonedMonoBehaviour
{
    public MapConfiguration MapConfiguration;
    public GameEvent MapConfigurated;
    public Vector2IntListVariable PlayerSpawnPositions;
    public FloatVariable MinTileCoverage;
    public FloatVariable MaxTileCreationAttemptFactor;
    public IntVariable StartLandPer100Tiles;
    public FloatVariable MapLength;
    public FloatVariable MapHeight;

    public override void DoAwake()
    {
        CreateMap();
    }

    public override void DoUpdate()
    {

    }

    private void CreateMap()
    {
        int length = (int) MapLength.Value;
        int height = (int) MapHeight.Value;
        int size = length * height;
        int minTileCount = (int)(MinTileCoverage.Value * size);
        int maxTileCreationAttempts = (int)(MaxTileCreationAttemptFactor.Value * size);
        int startLandsCount = StartLandPer100Tiles.Value * size / 100;
        List<Vector2Int> startLands = new List<Vector2Int>();
        int[,] map = new int[length, height];
        MapInit(ref map, length, height);
        CalcStartLands(ref startLands, startLandsCount, maxTileCreationAttempts, length, height);
        AddStartLands(ref map, startLands);
        AddTiles(ref map, maxTileCreationAttempts, minTileCount, length, height);
        UpdateMapConfiguration(map, length, height);
        UpdatePlayerSpawns();
    }

    void MapInit(ref int[,] map, int length, int height)
    {
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map[i, j] = -1;
            }
        }
    }

    void CalcStartLands(ref List<Vector2Int> startLands, int startLandsCount, int maxTileCreationAttempts, int length, int height)
    {
        Vector2Int startLandPos;
        int j = 0;
        for (int i = 0; i < maxTileCreationAttempts; i++)
        {
            startLandPos = new Vector2Int(Random.Range(0, length), Random.Range(0, height));
            bool isValid = true;
            for (int k = j; k < startLands.Count; k++)
            {
                if ((startLandPos - startLands[k]).magnitude <= 1)
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                startLands.Add(startLandPos);
                j++;
            }
            if (j >= startLandsCount)
            {
                break;
            }
        }
    }

    void AddStartLands(ref int[,] map, List<Vector2Int> startLands)
    {
        int startLandsCount = startLands.Count;
        for (int i = 0; i < startLandsCount; i++)
        {
            map[startLands[i].x, startLands[i].y] = i;
        }
    }

    void AddTiles(ref int[,] map, int maxTileCreationAttempts, int minTileCount, int length, int height)
    {
        Vector2Int NewTile;
        bool testCluster = false;
        int tileCount = 0;

        for (int i = 0; i < maxTileCreationAttempts; i++)
        {
            NewTile = new Vector2Int(Random.Range(0, length), Random.Range(0, height));
            if (map[NewTile.x, NewTile.y] == -1)
            {
                if (NewTile.x > 0)
                {
                    int leftMapValue = map[NewTile.x - 1, NewTile.y];
                    if (leftMapValue != -1)
                    {
                        map[NewTile.x, NewTile.y] = leftMapValue;
                        tileCount++;
                    }
                }
                if (NewTile.x < length - 1)
                {
                    int rightMapValue = map[NewTile.x + 1, NewTile.y];
                    CheckValue(ref map, rightMapValue, NewTile, ref tileCount, length, height);
                }
                if (NewTile.y > 0)
                {
                    int downMapValue = map[NewTile.x, NewTile.y - 1];
                    CheckValue(ref map, downMapValue, NewTile, ref tileCount, length, height);
                }
                if (NewTile.y < height - 1)
                {
                    int upMapValue = map[NewTile.x, NewTile.y + 1];
                    CheckValue(ref map, upMapValue, NewTile, ref tileCount, length, height);
                }
            }

            if (!testCluster) { testCluster = TestClusters(map, length, height); }
            if (testCluster && tileCount >= minTileCount) { break; }
        }
    }

    void CheckValue(ref int[,] map, int mapValue, Vector2Int newTile, ref int tileCount, int length, int height)
    {
        if (mapValue != -1)
        {
            if (map[newTile.x, newTile.y] == -1)
            {
                map[newTile.x, newTile.y] = mapValue;
                tileCount++;
            }
            if (mapValue != map[newTile.x, newTile.y])
            {
                MergeClusters(new Vector2Int(map[newTile.x, newTile.y], mapValue), ref map, length, height);
            }
        }
    }

    void MergeClusters(Vector2Int clustersToMerge, ref int[,] map, int length, int height)
    {
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (map[i,j] == clustersToMerge.y) { map[i,j] = clustersToMerge.x; }
            }
        }
    }

    bool TestClusters(int[,] map, int length, int height)
    {
        int cluster = -1;
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (map[i,j] != -1)
                {
                    if (cluster == -1)
                    {
                        cluster = map[i,j];
                    }
                    else if (cluster != map[i,j])
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    void UpdateMapConfiguration(int[,] map, int length, int height)
    {
        if (!MapConfiguration) return;
        MapConfiguration.TilePositions = new List<Vector2Int>();
        int halfLength = length / 2;
        int halfHeight = height / 2;
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (map[i, j] != -1)
                {
                    MapConfiguration.TilePositions.Add(new Vector2Int(i - halfLength, j - halfHeight));
                }
            }
        }
        MapConfigurated.Raise();
    }

    void UpdatePlayerSpawns()
    {
        if (!PlayerSpawnPositions) return;
        if (!MapConfiguration) return;
        PlayerSpawnPositions.Value = ShuffleList(MapConfiguration.TilePositions);
    }

    List<Vector2Int> ShuffleList(List<Vector2Int> list)
    {
        int j;
        for (int i = list.Count - 1; i > 1; i--)
        {
            j = Random.Range(0, i);
            Vector2Int k = list[j];
            list[j] = list[i];
            list[i] = k;
        }
        return list;
    }
}
