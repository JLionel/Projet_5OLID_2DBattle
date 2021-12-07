using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TwitchCommandHandler : ScriptableObject
{
    public abstract void HandleCommand(MessageData data);
}

public struct MessageData
{
    public string Author;
    public string Message;
}
