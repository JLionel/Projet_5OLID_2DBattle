using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : OrdonedMonoBehaviour
{
    [SerializeField] private GameEvent evnt;
    [SerializeField] private UnityEvent onEventRaised;

    public void OnEventRaised()
    {
        onEventRaised.Invoke();
    }

    public override void DoAwake()
    {
        evnt.RegisterListener(this);
    }

    public override void DoUpdate()
    {

    }

    private void OnDisable()
    {
        evnt.UnregisterListener(this);
    }
}
