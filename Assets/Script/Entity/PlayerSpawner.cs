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
    public StringListVariable PlayerNames;
    public override void DoStart()
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
        if (!SpawnPositions) { return; }
        if (!Tiles) { return; }
        if (!TileEntities) { return; }
        if (!PlayerPrefab) { return; }
        bool CanSpawn = false;
        Vector2 SpawnPosition = Vector2.zero;
        for (int i = 0; i < SpawnPositions.Value.Count; i++)
        {
            print(TileEntities.IsTileFree(SpawnPositions.Value[i]));
            if (Tiles.Exists(SpawnPositions.Value[i]) && TileEntities.IsTileFree(SpawnPositions.Value[i]))
            {
                SpawnPosition = SpawnPositions.Value[i];
                CanSpawn = true;
                break;
            }
        }

        if (!CanSpawn) { return; }
        GameObject Player = Instantiate(PlayerPrefab, new Vector3(SpawnPosition.x, SpawnPosition.y, 0), Quaternion.identity);
        PlayerIndexManager PlayerIndexManager = Player.GetComponent(typeof(PlayerIndexManager)) as PlayerIndexManager;

        if (!PlayerIndexManager) { return; }

        PlayerIndexManager.PlayerIndex = PlayerNames.Value.Count;
        PlayerNames.Value.Add(PlayerName);
        PlayerPositions.AddNewPosition(SpawnPositions.Value[PlayerIndexManager.PlayerIndex]);
    }
}
