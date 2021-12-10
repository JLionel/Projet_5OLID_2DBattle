using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MySingleton<GameStateManager>
{
    private GameState _gameState;
    public GameState GameState => _gameState;
    [SerializeField] private GameEvent FirstStateLoaded;
    
    //temporary
    public GameEvent JoinState;
    public GameEvent WaitActionState;
    public GameEvent ExecuteRoundState;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        FirstStateLoaded.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        _gameState.Tick();

        if (Input.GetKeyDown(KeyCode.A))
        {
            JoinState.Raise();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            WaitActionState.Raise();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ExecuteRoundState.Raise();
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

    protected override bool DoDestroyOnLoad { get => false; }
}
