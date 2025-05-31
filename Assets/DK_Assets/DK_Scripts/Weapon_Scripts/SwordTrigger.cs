using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrigger : MonoBehaviour
{
    [SerializeField]
    float _attackPower;

    private void OnTriggerEnter(Collider other)
    {
        Throwable throwableItem;
        DKEnemyController enemy;

        // if sword hits throwable item will break the object
        if (other.gameObject.TryGetComponent<Throwable>(out throwableItem))
            throwableItem.BreakObject();

        // else if sword hits enemy
        else if (other.gameObject.TryGetComponent<DKEnemyController>(out enemy))
            enemy.Hit(_attackPower, PlayerController.Instance.transform.position);
    }
}
