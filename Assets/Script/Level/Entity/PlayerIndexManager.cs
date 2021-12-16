using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndexManager : OrdonedMonoBehaviour
{
    public int Index;
    public PlayerPositions PlayerPosition;

    public override void DoAwake()
    {
        if (!PlayerPosition) { return; }

        Index = PlayerPosition.GetPlayerCount();
    }
    
    public override void DoUpdate()
    {
        
    }
    public void OnPlayerDeath(int deadPlayerIndex)
    {
        if (deadPlayerIndex < Index)
        {
            Index--;
        }
    }
}
