using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateEventListener : MonoBehaviour
{
    [SerializeField]
    private GameStateEvent eventState;

    [SerializeField]
    private List<UnityEvent> onEventRaised;

    public void OnEventRaised()
    {
        foreach (var eventRaised in onEventRaised)
        {
            eventRaised.Invoke();   
        }
    }

    public void Awake()
    {
        eventState.RegisterListener(this);
    }

    private void OnDisable()
    {
        eventState.UnregisterListener(this);
    }
}
