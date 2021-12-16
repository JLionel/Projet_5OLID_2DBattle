using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Game")]
public class GameEvent : ScriptableObject
{
    [SerializeField]
    private List<GameEventListener> listeners;

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }

}
