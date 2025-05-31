using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public float health;

    float _maxHealth;

    private void Start()
    {
        _maxHealth = health;
    }

    public void Hit(float damage)
    {
        health -= damage;

        if (damage > 0)
        {
            // took damage
            Debug.Log("took damage = " + damage);

            // if health is less than 0, it dies
            if (health < 0)
                Death();
        }

        else
        {
            // healed
            Debug.Log("healed = " + damage);

            // put a limit so that healing cant go over max health
            if (health > _maxHealth)
                health = _maxHealth;
        }
    }

    public async void Death()
    {
        Debug.Log("Death " + gameObject.name);

        // wait 5 seconds before destroying the object
        await Task.Delay(5000);

        Destroy(gameObject);
    }
}
