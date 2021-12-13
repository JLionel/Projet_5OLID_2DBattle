using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public List<PlayerData> PlayerDataToUpdate;

    public void OnPlayerDeath(int Index)
    {
        foreach (var PlayerData in PlayerDataToUpdate)
        {
            PlayerData.Remove(Index);
        }
    }
}
