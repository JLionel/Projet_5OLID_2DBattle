using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class PlayerEventListener : OrdonedMonoBehaviour
{
    [SerializeField]
    private PlayerEvent evnt;

    [SerializeField]
    private UnityEvent<int> onEventRaised;

    public void OnEventRaised(int index)
    {
        onEventRaised.Invoke(index);
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
