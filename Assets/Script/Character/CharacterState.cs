using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterState
{
    protected Character Character;

    public CharacterState(Character character)
    {
        this.Character = character;
    }
    
    public virtual void OnStateEnter(){}
    public virtual void OnStateExit(){}
    
    public abstract void Tick();
}
