using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSOInitializer : MyMonoBehaviour
{
    [SerializeField] private List<TilesData> _tilesDatas;

    void Start()
    {
        foreach (var TilesData in _tilesDatas)
        {
            TilesData.AddNew(new Vector2(transform.position.x, transform.position.y));
        }
    }
    public override void DoUpdate()
    {

    }
}
