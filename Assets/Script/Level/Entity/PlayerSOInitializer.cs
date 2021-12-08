using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSOInitializer : OrdonedMonoBehaviour
{
    [SerializeField] private List<PlayerData> _playerDatas;

    public override void DoAwake()
    {
        foreach (var PlayerData in _playerDatas)
        {
            PlayerData.AddNew();
        }
    }
    public override void DoUpdate()
    {

    }
}
