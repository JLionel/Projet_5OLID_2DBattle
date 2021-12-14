using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConfigurator : OrdonedMonoBehaviour
{
    public MapConfiguration MapConfiguration;
    public Vector2IntListVariable PlayerSpawnPositions;
    public FloatVariable MinTileCoverage;
    public FloatVariable MaxTileCreationAttemptFactor;
    public IntVariable StartLandPer100Tiles;
    public IntVariable MapLength;
    public IntVariable MapHeight;

    public override void DoAwake()
    {

    }

    public override void DoUpdate()
    {

    }

    private void CreateMap()
    {
        int Length = MapLength.Value;
        int Height = MapHeight.Value;
        int Size = Length * Height;
        int BigHoleAmount = Size / 25;
        int HoleAmount = Size / 5;
        int MinTileCount = (int)MinTileCoverage.Value * Size;
        int MaxTileCreationAttempts = (int)MaxTileCreationAttemptFactor.Value * Size;
        int StartLandsCount = StartLandPer100Tiles.Value / 100 * Size;
        List<Vector2Int> StartLands = new List<Vector2Int>();

        int[,] map = new int[Length,Height];
        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                map[i,j] = -1;
            }
        }

        Vector2Int StartLandPos;
        for (int i = 0; i < MaxTileCreationAttempts; i++)
        {
            int j = 0;
            StartLandPos = new Vector2Int(Random.Range(0, Length), Random.Range(0, Height));
            bool IsValid = true;
            for (int k = j; k < StartLands.Count; k++)
            {
                if ((StartLandPos - StartLands[k]).magnitude <= 1)
                {
                    IsValid = false;
                    break;
                }
            }
            if (IsValid)
            {
                StartLands.Add(StartLandPos);
                j++;
            }
            if (j >= StartLandsCount)
            {
                break;
            }
        }
        StartLandsCount = StartLands.Count;

        for (int i = 0; i < StartLandsCount; i++)
        {
            map[StartLands[i].x,StartLands[i].y] = i;
        }

        Vector2Int NewTile;
        List<int> JoinedClusters;
        for (int i = 0; i < MaxTileCreationAttempts; i++)
        {
            JoinedClusters = new List<int>();
            NewTile = new Vector2Int(Random.Range(0, Length), Random.Range(0, Height));
            if (map[NewTile.x,NewTile.y] == -1)
            {
                if (NewTile.x > 0)
                {
                    int LeftMapValue = map[NewTile.x - 1,NewTile.y];
                    if (LeftMapValue != -1)
                    {
                        map[NewTile.x,NewTile.y] = LeftMapValue;
                    }
                }
                if (NewTile.x < Length - 1)
                {
                    int RightMapValue = map[NewTile.x + 1,NewTile.y];
                    if (RightMapValue != -1)
                    {
                        if (map[NewTile.x,NewTile.y] == -1)
                        {
                            map[NewTile.x,NewTile.y] = RightMapValue;
                        }
                        if (RightMapValue != map[NewTile.x,NewTile.y])
                        {
                            MergeClusters(new Vector2Int(map[NewTile.x,NewTile.y], RightMapValue), map, Length, Height);
                        }
                    }
                }
                if (NewTile.y > 0)
                {
                    int DownMapValue = map[NewTile.x,NewTile.y - 1];
                    if (DownMapValue != -1)
                    {
                        if (map[NewTile.x,NewTile.y] == -1)
                        {
                            map[NewTile.x,NewTile.y] = DownMapValue;
                        }
                        if (DownMapValue != map[NewTile.x,NewTile.y])
                        {
                            MergeClusters(new Vector2Int(map[NewTile.x,NewTile.y], DownMapValue), map, Length, Height);
                        }
                    }
                }
                if (NewTile.y < Height - 1)
                {
                    int UpMapValue = map[NewTile.x,NewTile.y + 1];
                    if (UpMapValue != -1)
                    {
                        if (map[NewTile.x,NewTile.y] == -1)
                        {
                            map[NewTile.x,NewTile.y] = UpMapValue;
                        }
                        if (UpMapValue != map[NewTile.x,NewTile.y])
                        {
                            MergeClusters(new Vector2Int(map[NewTile.x,NewTile.y], UpMapValue), map, Length, Height);
                        }
                    }
                }
            }
        }
    }

    void MergeClusters(Vector2Int ClustersToMerge, int[,] map, int Length, int Height)
    {
        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                if (map[i,j] == ClustersToMerge.y) { map[i,j] = ClustersToMerge.x; }
            }
        }
    }

    bool TestClusters(int[,] map, int Length, int Height)
    {
        int Cluster = -1;
        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                if (map[i,j] != -1)
                {
                    if (Cluster == -1)
                    {
                        Cluster = map[i,j];
                    }
                    else if (Cluster != map[i,j])
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}
