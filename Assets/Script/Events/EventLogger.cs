using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLogger : MonoBehaviour
{
    void Logger(Object evnt, Object source)
    {
        Debug.Log($"{source.name} sent an event {evnt.name}");
    }

}
