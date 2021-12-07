using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent _event;
    [SerializeField] private UnityEvent onEventRaised;

    public void OnEventRaised()
    {
        onEventRaised.Invoke();
    }
    private void OnEnable()
    {
        _event.RegisterListener(this);
    }
    
    private void OnDisable()
    {
        _event.UnregisterListener(this);
    }
}
