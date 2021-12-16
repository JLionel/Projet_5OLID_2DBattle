using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerSOUpdater : MonoBehaviour
{
    public List<PlayerData> PlayerDataToUpdate;

    public void OnNewPlayerAdded()
    {
        foreach(var playerData in PlayerDataToUpdate)
        {
            playerData.AddNew();
        }
    }
}
