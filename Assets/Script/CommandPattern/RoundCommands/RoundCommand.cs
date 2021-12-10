using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RoundCommand : ScriptableObject
{
    public abstract void Execute(string playerName, PlayerCommand playerCommand);
}
