using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSOInitializer : OrdonedMonoBehaviour
{
    public List<PlayerData> PlayerDatas;
    public PlayerNames PlayerNames;

    public override void DoAwake()
    {
        foreach (var playerData in PlayerDatas)
        {
            playerData.Init();
        }
    }
    public override void DoUpdate()
    {

    }
}
