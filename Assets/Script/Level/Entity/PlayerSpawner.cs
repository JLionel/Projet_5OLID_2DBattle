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
    public GameEvent AddedNewPlayer;

    public override void DoAwake()
    {
        for (int i = 0; i < PlayerNames.Names.Count; i++)
        {
            SpawnPlayer(i);
        }
    }
    public override void DoUpdate()
    {

    }

    private void SpawnPlayer(int Index)
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

            if (Tiles.Exists(SpawnPosition) && TileEntities.TilePlayer(SpawnPosition) == -1)
            {
                CanSpawn = true;
                break;
            }
        }

        if (!CanSpawn) { return; }
        GameObject Player = Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity);
        Player.name = PlayerNames.Names[Index];

        AddedNewPlayer.Raise();

        PlayerMove PlayerMove = Player.GetComponent<PlayerMove>();
        if (!PlayerMove) { return; }
        PlayerMove.MoveTo(SpawnPosition);
    }
}
