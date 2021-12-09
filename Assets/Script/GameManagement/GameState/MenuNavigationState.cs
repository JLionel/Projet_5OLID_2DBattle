using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuNavigationState : GameState
{
    public MenuNavigationState(GameStateManager gameStateManager) : base(gameStateManager)
    {
        _statesName = StatesName.Navigation;
    }
    
    public override void Tick()
    {
        
    }
}
