using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/GameWithSource")]
public class GameEventWithSource : ScriptableObject
{
    [SerializeField]
    private List<GameEventWithSourceListener> listeners;

    public void Raise(Object source)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(source);
        }
    }

    public void RegisterListener(GameEventWithSourceListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventWithSourceListener listener)
    {
        listeners.Remove(listener);
    }

}
