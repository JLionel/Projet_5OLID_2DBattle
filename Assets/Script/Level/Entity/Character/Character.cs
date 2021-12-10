using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player")]
public class Character : ScriptableObject
{
    private CharacterState _characterState;
    
    public CharacterState CharacterState { get => _characterState; }

    public void Init()
    {
        ChangeState(new IdleState(this));
    }

    public void ChangeState(CharacterState newState)
    {
        if (_characterState != null)
        {
            _characterState.OnStateExit();
        }

        _characterState = newState;
        _characterState.OnStateEnter();
    }
}
