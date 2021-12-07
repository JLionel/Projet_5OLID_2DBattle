using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerNames")]
public class PlayerNames : LevelData
{
    public List<string> NamesList = new List<string>();

    public override void Init()
    {
        NamesList = new List<string>();
    }
}

