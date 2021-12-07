using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileIndexManager : MyMonoBehaviour
{
    public int Index;
    public Tiles Tiles;

    void Start()
    {
        Index = Tiles.TileList.Count;
    }

    public override void DoUpdate()
    {

    }
}