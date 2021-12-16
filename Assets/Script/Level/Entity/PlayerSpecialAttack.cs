using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour
{
    public PlayerIndexManager PlayerIndexManager;
    public PlayerClasses PlayerClasses;
    public Tiles Tiles;
    public TileEntities TileEntities;
    public PlayerHealth PlayerHealth;
    public TileEvent AttackOnTile;

    private void SpecialAttack(Vector2Int position, Vector2Int direction)
    {
        if (!PlayerIndexManager) { return; }

        List<Vector2Int> specialAttackPos = PlayerClasses.PlayerClassesList[PlayerIndexManager.Index].GetSpecialAttackPos(position, direction);

        Vector2Int attackPos;
        int tilePlayer;
        for (int i = 0; i < specialAttackPos.Count; i++)
        {
            attackPos = specialAttackPos[i];
            if (Tiles.Exists(attackPos))
            {
                tilePlayer = TileEntities.TilePlayer(attackPos);
                if (tilePlayer != -1)
                {
                    Debug.Log(PlayerIndexManager.Index + " special attacked " + tilePlayer + " from " + position + " to " + attackPos);
                    PlayerHealth.DecreaseHealth(tilePlayer);
                }
                if (!AttackOnTile) { return; }
                AttackOnTile.Raise(attackPos);
            }
        }
    }
}
