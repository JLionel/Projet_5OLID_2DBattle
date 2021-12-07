using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Twitch/Command/Commands Collection")]
[Serializable]
public class CommandsCollection : ScriptableObject
{
    public List<TwitchCommandHandler> _availableCommands = new List<TwitchCommandHandler>();
    
    public void ExecuteCommands(string command, MessageData data)
    {
        //remove "!"
        command = command.Substring(1);
        bool multiAction;
        if (IsCommandValid(command,out multiAction))
        {
            if (multiAction)
            {
                foreach (var letter in command)
                {
                    SearchCommand(letter.ToString())?.HandleCommand(data);
                }
            }
            else
                SearchCommand(command)?.HandleCommand(data);
        }
    }

    private bool IsCommandValid(string command, out bool multiAction)
    {
        multiAction = false;
        if (SearchCommand(command))
            return true;

        if (command.Length > 3)
            return false;

        foreach (var letter in command)
        {
            if (!SearchCommand(letter.ToString()))
                return false;
        }

        multiAction = true;
        return true;
    }
    

    private TwitchCommandHandler SearchCommand(string commandName)
    {
        foreach (var command in _availableCommands)
        {
            if (command.Find(commandName))
                return command;
        }
        return null;
    }
}
