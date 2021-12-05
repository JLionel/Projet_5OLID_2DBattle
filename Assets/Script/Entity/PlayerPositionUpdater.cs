using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionUpdater : MonoBehaviour
{
    public PlayerPosition PlayerPosition;

    public void OnPlayerPositionChanged()
    {
        if (!PlayerPosition) return;
        Vector2 PlayerPositionVector = PlayerPosition.GetValue();
        transform.position = new Vector3(PlayerPositionVector.x, PlayerPositionVector.y, 0);
    }
}
