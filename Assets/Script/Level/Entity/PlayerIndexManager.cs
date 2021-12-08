using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndexManager : OrdonedMonoBehaviour
{
    public int Index;
    public PlayerNames PlayerNames;

    public override void DoAwake()
    {
        Index = PlayerNames.NamesList.Count;
    }
    public override void DoUpdate()
    {
        
    }
}
