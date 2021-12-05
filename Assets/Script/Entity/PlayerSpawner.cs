using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MyMonoBehaviour
{
    public GameObject PlayerPrefab;
    public Tiles Tiles;
    public Vector2Variable SpawnPosition;
    public PlayerPosition PlayerPosition;
    public override void DoStart()
    {
        SpawnPlayer();
    }
    public override void DoUpdate()
    {

    }

    private void SpawnPlayer()
    {
        if (!Tiles.Exists(SpawnPosition.Value)) return;
        if (!PlayerPrefab) return;
        GameObject Player = Instantiate(PlayerPrefab, new Vector3(SpawnPosition.Value.x, SpawnPosition.Value.y, 0), Quaternion.identity);
        PlayerPosition.SetValue(SpawnPosition.Value);
    }
}
