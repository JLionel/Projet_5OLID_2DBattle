using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TwitchCommandHandler : ScriptableObject
{
    public List<string> twitchCommandName;
    public bool needParams;
    
    
    [SerializeField]protected Command _commandExecuted;

    public abstract void HandleCommand(MessageData data);

    public bool Find(string command)
    {
        return twitchCommandName.Contains(command);
    }
}

public struct MessageData
{
    public string Author;
    public string Message;
}
