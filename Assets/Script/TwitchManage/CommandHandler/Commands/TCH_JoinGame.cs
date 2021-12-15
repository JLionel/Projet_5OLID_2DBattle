using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Twitch/Command/JoinGame")]
public class TCH_JoinGame : TwitchCommandHandler
{
    [SerializeField] private List<PlayerClass> ClassExistent;
    
    
    public override void HandleCommand(MessageData data)
    {
        int result = 0;
        if(data.Message.Length == 1 && int.TryParse(data.Message, out result))
        {
            var commandCast = (JoinPlayerCommand) playerCommandExecuted;
            commandCast.PlayerClass = ClassExistent[result];
            commandCast.Execute(data.Author);
        }
    }
}
