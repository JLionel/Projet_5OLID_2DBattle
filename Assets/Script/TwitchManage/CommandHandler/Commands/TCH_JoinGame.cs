using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Twitch/Command/JoinGame")]
public class TCH_JoinGame : TwitchCommandHandler
{
    [SerializeField] private List<PlayerClass> ClassExistent;
    
    
    public override void HandleCommand(MessageData data)
    {
        Debug.Log("Join Command");
        int result = 0;
        if(int.TryParse(data.Message, out result))
        {
            Debug.Log("Valid Command");
            if(result >= 0 && result < ClassExistent.Count)
            {
                var commandCast = (JoinPlayerCommand) playerCommandExecuted;
                commandCast.PlayerClass = ClassExistent[result];
                commandCast.Execute(data.Author);
            }
        }
    }
}
