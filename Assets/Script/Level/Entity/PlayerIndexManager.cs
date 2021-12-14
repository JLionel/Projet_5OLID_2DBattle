using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndexManager : MonoBehaviour
{
    public int Index;

    public void OnPlayerDeath(int DeadPlayerIndex)
    {
        if (DeadPlayerIndex < Index)
        {
            Index--;
        }
    }
}
