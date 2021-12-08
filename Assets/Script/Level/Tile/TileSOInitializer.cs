using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSOInitializer : OrdonedMonoBehaviour
{
    [SerializeField] private List<TileData> _tileDatas;

    public override void DoAwake()
    {
        foreach (var TilesData in _tileDatas)
        {
            TilesData.AddNew(new Vector2Int((int)transform.position.x, (int)transform.position.y));
        }
    }
    public override void DoUpdate()
    {
        
    }
}
