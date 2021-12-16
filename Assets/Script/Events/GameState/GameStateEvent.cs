using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Events/GameState/Event")]
public class GameStateEvent : ScriptableObject
{
    [SerializeField]
    private List<GameStateEventListener> listeners;

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameStateEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameStateEventListener listener)
    {
        listeners.Remove(listener);
    }
}
