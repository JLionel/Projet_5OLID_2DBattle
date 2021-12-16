using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Player")]
public class PlayerEvent : ScriptableObject
{
    [SerializeField]
    private List<PlayerEventListener> listeners;

    public void Raise(int Index)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(Index);
        }
    }

    public void RegisterListener(PlayerEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(PlayerEventListener listener)
    {
        listeners.Remove(listener);
    }

}
