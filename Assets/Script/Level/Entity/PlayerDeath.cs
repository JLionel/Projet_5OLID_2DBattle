using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public List<PlayerData> PlayerDataToUpdate;
    public PlayerGO PlayerGO;

    public void OnPlayerDeath(int index)
    {
        if (!PlayerGO) { return; }
        Destroy(PlayerGO.GameObjects[index]);
        foreach (var playerData in PlayerDataToUpdate)
        {
            playerData.Remove(index);
        }
        print(index + " ded");
    }
}
