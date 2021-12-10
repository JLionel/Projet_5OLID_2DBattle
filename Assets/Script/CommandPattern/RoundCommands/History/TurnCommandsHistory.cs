using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnCommandsHistory
{
    public Dictionary<string, PlayerCommand> allCommand = new Dictionary<string, PlayerCommand>();

    public void ExecuteCommands()
    {
        foreach (var command in allCommand)
        {
            command.Value.Execute(command.Key);
        }
    }

    public bool AddCommand(string playerPseudo, PlayerCommand playerCommand)
    {
        if (HaveAnAction(playerPseudo))
            return false;
        Debug.Log("Add turn command");
        allCommand.Add(playerPseudo, playerCommand);
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
