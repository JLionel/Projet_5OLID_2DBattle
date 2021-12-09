using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MySingleton<GameStateManager>
{
    private GameState _gameState;
    public GameState GameState => _gameState;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new MenuNavigationState(this));
    }

    // Update is called once per frame
    void Update()
    {
        _gameState.Tick();

        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeState(new JoinLobbyState(this));
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeState(new WaitActionState(this, RoundCommandHistory.Instance.EnterActionTimer.Value));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeState(new ExecuteRoundState(this));
        }

        Debug.Log($"Current state : {GameState.StatesName.ToString()}");
    }
    
    public void ChangeState(GameState newState)
    {
        if (_gameState != null)
        {
            _gameState.OnStateExit();
        }

        _gameState = newState;
        _gameState.OnStateEnter();
    }

    protected override bool DoDestroyOnLoad { get; }
}
