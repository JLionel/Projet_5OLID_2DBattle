using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionUpdater : MonoBehaviour
{
    public PlayerPositions PlayerPositions;
    public PlayerIndexManager PlayerIndexManager;

    public void OnPlayerPositionChanged()
    {
        if (!PlayerPositions) return;
        if (!PlayerIndexManager) return;
        if (PlayerIndexManager.PlayerIndex == 0) return;

        Vector2 PlayerPositionVector = PlayerPositions.GetPosition(PlayerIndexManager.PlayerIndex);
        transform.position = new Vector3(PlayerPositionVector.x, PlayerPositionVector.y, 0);
    }
}