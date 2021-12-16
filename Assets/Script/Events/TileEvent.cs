using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Tile")]
public class TileEvent : ScriptableObject
{
    [SerializeField]
    private List<TileEventListener> listeners;

    public void Raise(Vector2Int position)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(position);
        }
    }

    public void RegisterListener(TileEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(TileEventListener listener)
    {
        listeners.Remove(listener);
    }

}
