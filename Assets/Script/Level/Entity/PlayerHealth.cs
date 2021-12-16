using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerHealth")]
public class PlayerHealth : PlayerData
{
    public int MaxHealth = 2;
    public List<int> PlayerHealthList = new List<int>();
    public PlayerEvent PlayerDeath;

    public override void Init()
    {
        PlayerHealthList = new List<int>();
    }

    public void DecreaseHealth(int index)
    {
        PlayerHealthList[index]--;
        if (PlayerHealthList[index] <= 0)
        {
            PlayerDeath.Raise(index);
        }
    }

    public override void Remove(int index)
    {
        PlayerHealthList.RemoveAt(index);
    }

    public void SetSize(int size)
    {
        PlayerHealthList = new List<int>(size);
    }

    public override void AddNew()
    {
        PlayerHealthList.Add(MaxHealth);
    }

    public void ClearList()
    {
        PlayerHealthList.Clear();
    }
}
