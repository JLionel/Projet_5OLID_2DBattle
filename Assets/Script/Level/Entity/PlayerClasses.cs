using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerClasses")]
public class PlayerClasses : PlayerData
{
    public List<PlayerClass> AvailableClasses = new List<PlayerClass>();
    public List<PlayerClass> PlayerClassesList = new List<PlayerClass>();

    public override void Init()
    {
        PlayerClassesList = new List<PlayerClass>();
    }

    public void SetSize(int size)
    {
        PlayerClassesList = new List<PlayerClass>(size);
    }

    public override void AddNew()
    {
        PlayerClassesList.Add(AvailableClasses[0]);
    }

    public override void Remove(int index)
    {
        PlayerClassesList.RemoveAt(index);
    }

    public void AddNew(string className)
    {
        PlayerClassesList.Add(AvailableClasses[ClassIndex(className)]);
    }

    public void ClearList()
    {
        PlayerClassesList.Clear();
    }

    public void SetPlayerClass(int index, string className)
    {
        PlayerClassesList[index] = AvailableClasses[ClassIndex(className)];
    }

    public int ClassIndex(string className)
    {
        for (int i = 0; i < AvailableClasses.Count; i++)
        {
            if (AvailableClasses[i].name == className)
            {
                return i;
            }
        }
        return 0;
    }
}

