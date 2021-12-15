using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnCommandsHistory
{
    private Dictionary<string, PlayerCommand> _allCommand = new Dictionary<string, PlayerCommand>();

    public async void ExecuteCommands()
    {
        foreach (var command in _allCommand)
        {
            command.Value.Execute(command.Key);
        }
    }

    public bool AddCommand(string playerPseudo, PlayerCommand playerCommand)
    {
        if (HaveAnAction(playerPseudo))
            return false;
        Debug.Log("Add turn command");
        _allCommand.Add(playerPseudo, playerCommand);
        return true;
    }

    private bool HaveAnAction(string playerPseudo)
    {
        Debug.Log("Have action ?");
        
        return _allCommand.ContainsKey(playerPseudo);
    }

    public void ClearCommands()
    {
        _allCommand.Clear();
    }
}
