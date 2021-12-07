using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndexManager : MyMonoBehaviour
{
    public int Index;
    public StringListVariable PlayerNames;

    void Start()
    {
        Index = PlayerNames.Value.Count - 1;
    }
    public override void DoUpdate()
    {

    }
}
