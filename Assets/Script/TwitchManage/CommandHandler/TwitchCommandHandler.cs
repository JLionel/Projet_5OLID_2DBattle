using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TwitchCommandHandler : ScriptableObject
{
    public List<string> commandName;
    public bool needParams;
    public abstract void HandleCommand(MessageData data);

    public bool Find(string command)
    {
        return commandName.Contains(command);
    }
}

public struct MessageData
{
    public string Author;
    public string Message;
}
