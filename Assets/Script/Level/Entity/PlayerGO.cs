using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerGameObjects")]
public class PlayerGO : PlayerData
{
    public List<GameObject> GameObjects = new List<GameObject>();

    public override void Init()
    {
        GameObjects = new List<GameObject>();
    }

    public void SetSize(int size)
    {
        GameObjects = new List<GameObject>(size);
    }

    public void Set(int index, GameObject gameObject)
    {
        Debug.Log(GameObjects.Count + "   " + index);
        GameObjects[index] = gameObject;
    }

    public override void AddNew()
    {

    }

    public override void Remove(int index)
    {
        GameObjects.RemoveAt(index);
    }

    public void AddNew(GameObject gameObject)
    {
        GameObjects.Add(gameObject);
    }

    public bool Contains(GameObject gameObject)
    {
        return GameObjects.Contains(gameObject);
    }

    public void ClearList()
    {
        GameObjects.Clear();
    }

    public int GetPlayerCount()
    {
        return GameObjects.Count;
    }
}

