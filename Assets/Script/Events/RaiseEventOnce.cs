using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEventOnce : MonoBehaviour
{
    [SerializeField] private GameStateEvent gameStateEvent;

    private void Start()
    {
        gameStateEvent.Raise();
    }
}
