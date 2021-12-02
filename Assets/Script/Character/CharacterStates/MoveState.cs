using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionMove
{
    Up,
    Down,
    Left,
    Right
}

public class MoveState : CharacterState
{
    private DirectionMove _directionMove;
    
    public override void Tick()
    {
        throw new System.NotImplementedException();
    }

    public MoveState(Character character, DirectionMove directionMove) : base(character)
    {
        _directionMove = directionMove;
    }
}
