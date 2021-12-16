using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RoundCommandHistory : MySingleton<RoundCommandHistory>
{
    private List<TurnCommandsHistory> _allTurns = new List<TurnCommandsHistory>(3);
    [SerializeField] private FloatVariable timeBtwTurns;

    [SerializeField] public FloatVariable PlayerDelay;

    protected override bool DoDestroyOnLoad => true;
    
    public BoolVariable EndRound;
    
    public bool EndTurn;

    private void Start()
    {
        Init();
    }

    public void ExecuteRound()
    {
        EndRound.Value = false;
        UpdateRoundDelay();
        StartCoroutine(ExecuteRoundTimed());
    }

    //TODO Check if in the right state
    public void AddCommand(string playerPseudo, PlayerCommand playerCommand)
    {
        foreach (var turn in _allTurns)
        {
            var response = turn.AddCommand(playerPseudo, playerCommand);
            if (response)
                return;
        }
    }

    private IEnumerator ExecuteRoundTimed()
    {
        foreach (var turn in _allTurns)
        {
            EndTurn = false;
            StartCoroutine(turn.ExecuteCommands(PlayerDelay.Value));
            yield return new WaitUntil(() => EndTurn);
        }
        ClearTurnsCommands();
        EndRound.Value = true;
        yield return null;
    }

    private void UpdateRoundDelay()
    {
        timeBtwTurns.Value = 0;
        foreach (var turn in _allTurns)
        {
            timeBtwTurns.Value += turn.NumberOfActions() * PlayerDelay.Value;
        }
    }

    private void ClearTurnsCommands()
    {
        foreach (var turn in _allTurns)
        {
            turn.ClearCommands();
        }
    }

    private void Init()
    {
        for (int i = 0; i < 3; i++)
        {
            _allTurns.Add(new TurnCommandsHistory());
        }
    }
}
