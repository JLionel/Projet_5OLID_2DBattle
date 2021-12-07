using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnCommandsHistory
{
    public Dictionary<string, Command> allCommand = new Dictionary<string, Command>();

    public void ExecuteCommands()
    {
        foreach (var command in allCommand)
        {
            command.Value.Execute();
        }
    }

    public bool AddCommand(string playerPseudo, Command command)
    {
        if (HaveAnAction(playerPseudo))
            return false;
        Debug.Log("Add turn command");
        allCommand.Add(playerPseudo, command);
        return true;
    }

    private bool HaveAnAction(string playerPseudo)
    {
        Debug.Log("Have action ?");
        
        return allCommand.ContainsKey(playerPseudo);
    }

    public void ClearCommands()
    {
        allCommand.Clear();
    }
}
