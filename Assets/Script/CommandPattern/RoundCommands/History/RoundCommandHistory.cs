using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RoundCommandHistory : MySingleton<RoundCommandHistory>
{
    private List<TurnCommandsHistory> _allTurns = new List<TurnCommandsHistory>(3);
    private float _timeBtwTurns = 1.5f;

    [SerializeField] public FloatVariable EnterActionTimer;
    
    //temporary
    public bool endRound;

    //TODO to delet
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Execute round !!");
            ExecuteRound();
        }
    }

    private void Start()
    {
        Init();
    }

    public void ExecuteRound()
    {
        endRound = false;
        StartCoroutine(ExecuteRoundTimed());
    }

    //TODO Check if in the right state
    public void AddCommand(string playerPseudo, PlayerCommand playerCommand)
    {
        Debug.Log($"try adding command {_allTurns.Count}");
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
            turn.ExecuteCommands();
            yield return new WaitForSeconds(_timeBtwTurns);
        }
        ClearTurnsCommands();
        endRound = true;
        yield return null;
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
    protected override bool DoDestroyOnLoad { get; }
}
