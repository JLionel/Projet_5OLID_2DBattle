using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDisplay : MonoBehaviour
{
    public GameObject AttackDisplayPrefab;

    public IEnumerator DisplayAttackCoroutine(Vector2Int position)
    {
        GameObject attackDisplay = Instantiate(AttackDisplayPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(attackDisplay);
    }


    public void OnAttack(Vector2Int position)
    {
        StartCoroutine(DisplayAttackCoroutine(position));
    }
}
