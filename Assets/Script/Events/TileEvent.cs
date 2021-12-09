using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Tile")]
public class TileEvent : ScriptableObject
{
    [SerializeField]
    private List<TileEventListener> _listeners;

    private Vector2Int _position;

    public void Raise(Vector2Int Position)
    {
        _position = Position;
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(TileEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(TileEventListener listener)
    {
        _listeners.Remove(listener);
    }

}
