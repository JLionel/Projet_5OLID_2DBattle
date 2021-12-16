using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSOInitializer : OrdonedMonoBehaviour
{
    [SerializeField] private List<TileData> tileDatas;

    public override void DoAwake()
    {
        foreach (var tileData in tileDatas)
        {
            tileData.Init();
        }
    }
    public override void DoUpdate()
    {
        
    }
}
