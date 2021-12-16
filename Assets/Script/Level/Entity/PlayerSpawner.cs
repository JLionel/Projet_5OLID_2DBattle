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

    [SerializeField] private TwitchAcountCredentials twitchAccountCredentials;
    [SerializeField] private RoundCommand addAction;
    [SerializeField] private List<KeyCode> keyPressed;
    [SerializeField] private List<PlayerCommand> commands;

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

    private void SpawnPlayer(int index)
    {
        if (!SpawnPositions) { return; }
        if (!Tiles) { return; }
        if (!TileEntities) { return; }
        if (!PlayerPrefab) { return; }
        bool canSpawn = false;
        Vector2Int spawnPosition = Vector2Int.zero;
        for (int i = 0; i < SpawnPositions.Value.Count; i++)
        {
            spawnPosition = SpawnPositions.Value[i];

            if (Tiles.Exists(spawnPosition) && TileEntities.TilePlayer(spawnPosition) == -1)
            {
                canSpawn = true;
                break;
            }
        }

        if (!canSpawn) { return; }
        GameObject player = Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity);
        player.name = PlayerNames.Names[index];

        //add script to the local player who has the acount twitch name
        if (player.name == twitchAccountCredentials.TwitchAccountName)
        {
            var localPlayerMove = player.AddComponent<LocalPlayerMove>();
            localPlayerMove.RoundCommand = addAction;
            localPlayerMove.KeyPressed = keyPressed;
            localPlayerMove.Commands = commands;
        }

        AddedNewPlayer.Raise();

        PlayerMove playerMove = player.GetComponent<PlayerMove>();
        if (!playerMove) { return; }
        playerMove.MoveTo(spawnPosition);
    }
}
