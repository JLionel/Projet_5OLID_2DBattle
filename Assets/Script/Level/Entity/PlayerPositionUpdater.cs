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
        Vector2Int playerPositionVector = PlayerPositions.GetPosition(PlayerIndexManager.Index);
        transform.position = new Vector3(playerPositionVector.x, playerPositionVector.y, 0);
    }
}