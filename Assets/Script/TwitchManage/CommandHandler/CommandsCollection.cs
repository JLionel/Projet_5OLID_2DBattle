using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Twitch/Command/Commands Collection")]
[Serializable]
public class CommandsCollection : ScriptableObject
{
    public List<string> _keys = new List<string>();
    public List<TwitchCommandHandler> _values = new List<TwitchCommandHandler>();
    
    
    public Dictionary<string, TwitchCommandHandler> _availableComands;

    public void Init()
    {
        _availableComands = new Dictionary<string, TwitchCommandHandler>();
        for (int i = 0; i < Mathf.Min(_keys.Count, _values.Count); i++)
        {
            _availableComands.Add(_keys[i], _values[i]);
        }
    }

    public void ExecuteCommands(string command, MessageData data)
    {
        //remove "!"
        command = command.Substring(1);
        if (_availableComands.ContainsKey(command))
        {
            _availableComands[command].HandleCommand(data);
        }
    }
}
