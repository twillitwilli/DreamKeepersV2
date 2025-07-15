using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrigger : MonoBehaviour
{
    [SerializeField]
    Sword _sword;

    private void OnTriggerEnter(Collider other)
    {
        Throwable throwableItem;
        DKEnemyController enemy;

        // if sword hits throwable item will break the object
        if (other.gameObject.TryGetComponent<Throwable>(out throwableItem))
            throwableItem.BreakObject();

        // else if sword hits enemy
        else if (other.gameObject.TryGetComponent<DKEnemyController>(out enemy))
        {
            // checks to see if the player landed a critical hit
            float attackDamage = _sword.CriticalHit(_sword.currentAttackDamage);

            // applies damage to enemy
            enemy.Hit(_sword.currentAttackDamage, PlayerController.Instance.transform.position);
        }
            
    }
}
