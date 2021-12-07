using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSOInitializer : MyMonoBehaviour
{
    [SerializeField] private List<LevelData> _levelDatas;
    void Start()
    {
        foreach (var LevelData in _levelDatas)
        {
            LevelData.Init();
        }
    }

    public override void DoUpdate()
    {
        
    }
}
