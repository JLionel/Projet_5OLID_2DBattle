using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class GameEventWithSourceListener : MonoBehaviour
{
    [SerializeField]
    private GameEventWithSource evnt;

    [SerializeField]
    private UnityEvent<Object, Object> onEventRaised;

    public void OnEventRaised(Object source)
    {
        onEventRaised.Invoke(evnt, source);
    }

    private void OnEnable()
    {
        evnt.RegisterListener(this);
    }

    private void OnDisable()
    {
        evnt.UnregisterListener(this);
    }
}
