using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "GameManagement/GameState/WaitActionState")]
public class WaitActionState : GameState
{
    [SerializeField] private FloatVariable waitTimer;
    
    [SerializeField] private PlayerNames playerList;
    [SerializeField] private PlayerClasses playerClasses;
    [SerializeField] private StringVariable winnerName;
    
    [SerializeField] private GameStateEvent endGameState;

    [SerializeField] private GameEvent enterWaitState;

    private float _saveWaitTimer;
    
    public override void Tick()
    {
        if (playerList.GetPlayerCount() <= 1)
        {
            winnerName.Value = playerList.GetPlayerCount() == 1? playerList.Names[0] : "";
            playerList.ClearList();
            playerClasses.PlayerClassesList.Clear();
            endGameState.Raise();
        }else
        {
            waitTimer.Value -= Time.deltaTime;
            if (waitTimer.Value <= 0)
            {
                DefaultNextState.Raise();
            }
        }
    }
    
    public override void OnStateEnter()
    {
        enterWaitState.Raise();
        _saveWaitTimer = waitTimer.Value;
        if (playerList.GetPlayerCount() > 1)
        {
            TwitchChatConnected.Instance.WriteMessage(
                "Enter your three actions !!!! Move with !z, !q, !s, !d. You can combine those command up to three like !zqd");
        }
    }

    public override void OnStateExit()
    {
        waitTimer.Value = _saveWaitTimer;

        if (playerList.GetPlayerCount() <= 1)
        {
            TwitchChatConnected.Instance.WriteMessage(winnerName.Value == ""
                ? "It's a draw PoroSad"
                : $"GG  PowerUpL @{winnerName.Value} PowerUpR won this match PogChamp");
        }
    }
}
