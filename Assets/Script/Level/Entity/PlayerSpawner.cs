using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MyMonoBehaviour
{
    public GameObject PlayerPrefab;
    public Tiles Tiles;
    public TileEntities TileEntities;
    public Vector2ListVariable SpawnPositions;
    public PlayerPositions PlayerPositions;
    public PlayerNames PlayerNames;

    void Start()
    {
        for(int i = 0; i < 2; i++)
        {
            SpawnPlayer("Player"+i);
        }
    }
    public override void DoUpdate()
    {

    }

    private void SpawnPlayer(string PlayerName)
    {
        print(Tiles.TileList.Count);
        print("yolo1");
        if (!SpawnPositions) { return; }
        if (!Tiles) { return; }
        if (!TileEntities) { return; }
        if (!PlayerPrefab) { return; }
        print("yolo2");
        bool CanSpawn = false;
        Vector2 SpawnPosition = Vector2.zero;
        for (int i = 0; i < SpawnPositions.Value.Count; i++)
        {
            SpawnPosition = SpawnPositions.Value[i];
            print(Tiles.Exists(SpawnPosition) + "    " + TileEntities.IsTileFree(SpawnPosition));

            if (Tiles.Exists(SpawnPosition) && TileEntities.IsTileFree(SpawnPosition))
            {
                print("yolo");
                CanSpawn = true;
                break;
            }
        }

        print("yolo3");
        if (!CanSpawn) { return; }
        print("yolo4");
        GameObject Player = Instantiate(PlayerPrefab, new Vector3(SpawnPosition.x, SpawnPosition.y, 0), Quaternion.identity);
        PlayerNames.NamesList.Add(PlayerName);
        PlayerPositions.AddNewPosition(SpawnPositions.Value[PlayerNames.NamesList.Count]);
        print("yolo7");
    }
}
