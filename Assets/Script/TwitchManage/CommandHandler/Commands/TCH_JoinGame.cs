using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Twitch/Command/JoinGame")]
public class TCH_JoinGame : TwitchCommandHandler
{
    [SerializeField] private List<PlayerClass> classExistent;
    
    
    public override void HandleCommand(MessageData data)
    {
        int result = 0;
        if(int.TryParse(data.Message, out result))
        {
            if(result >= 0 && result < classExistent.Count)
            {
                var commandCast = (JoinPlayerCommand) playerCommandExecuted;
                commandCast.PlayerClass = classExistent[result];
                commandCast.Execute(data.Author);
            }
        }
    }
}
