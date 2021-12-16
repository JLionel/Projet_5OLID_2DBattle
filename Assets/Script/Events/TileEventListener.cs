using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class TileEventListener : OrdonedMonoBehaviour
{
    [SerializeField]
    private TileEvent evnt;

    [SerializeField]
    private UnityEvent<Vector2Int> onEventRaised;

    public void OnEventRaised(Vector2Int position)
    {
        onEventRaised.Invoke(position);
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
