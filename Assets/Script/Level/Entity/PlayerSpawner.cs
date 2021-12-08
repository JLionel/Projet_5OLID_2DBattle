using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : OrdonedMonoBehaviour
{
    public GameObject PlayerPrefab;
    public Tiles Tiles;
    public TileEntities TileEntities;
    public Vector2IntListVariable SpawnPositions;
    public PlayerPositions PlayerPositions;
    public PlayerNames PlayerNames;

    public override void DoAwake()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnPlayer("Player" + i);
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
        Vector2Int SpawnPosition = Vector2Int.zero;
        for (int i = 0; i < SpawnPositions.Value.Count; i++)
        {
            SpawnPosition = SpawnPositions.Value[i];
            //print(Tiles.Exists(SpawnPosition) + "    " + TileEntities.IsTileFree(SpawnPosition));

            if (Tiles.Exists(SpawnPosition) && TileEntities.IsTileFree(SpawnPosition))
            {
                CanSpawn = true;
                break;
            }
        }

        if (!CanSpawn) { return; }
        GameObject Player = Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity);

        PlayerNames.SetLastPlayerName(PlayerName);

        PlayerMove PlayerMove = Player.GetComponent<PlayerMove>();
        if (!PlayerMove) { return; }
        PlayerMove.MoveTo(SpawnPosition);
    }
}
