using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerNames")]
public class PlayerNames : PlayerData
{
    public List<string> NamesList = new List<string>();

    public override void Init()
    {
        NamesList = new List<string>();
    }

    public override void AddNew()
    {
        NamesList.Add("");
    }
    public void SetLastPlayerName(string Name)
    {
        NamesList[NamesList.Count - 1] = Name;
    }
}

