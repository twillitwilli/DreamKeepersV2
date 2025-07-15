using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    BoxCollider _swordTrigger;

    [SerializeField]
    GameObject
        _swingEffect,
        _coverEffect;

    public int
        minimumDamage,
        maximumDamage;

    [Range(5f, 75f)]
    public int critRate;
    [Range(.25f, 3)]
    public float critDamagemultipler;

    [HideInInspector]
    public float currentAttackDamage;

    public VRHandController currentHand { get; set; }

    private async void Update()
    {
        if (currentHand != null)
        {
            if (!currentHand.trackHandVelocity)
                currentHand.trackHandVelocity = true;

            // tracking hand velocity
            else
            {
                float swordVelocity = currentHand.GetHandVelocity();

                // limits max sword velocity to avoid exploit
                if (swordVelocity > 15)
                    swordVelocity = 15;

                // Activate sword trigger and get current damage amount
                if (swordVelocity > 7)
                {
                    currentAttackDamage = (Random.Range(minimumDamage, maximumDamage)) * swordVelocity;
                    Debug.Log("Strong Attack Damage " + currentAttackDamage);

                    // Sword Swing Attack
                    _swordTrigger.isTrigger = true;

                    // Turn On Swing Effect
                    _swingEffect.SetActive(true);
                }

                else if (swordVelocity > 5 && swordVelocity < 8)
                    Debug.Log("Swing Faster");

                // Not Attacking
                else if (_swordTrigger.isTrigger)
                {
                    // Turn off Sword Swing Attack
                    _swordTrigger.isTrigger = false;

                    // wait half a second
                    await Task.Delay(1000);

                    // turn off swing effect
                    _swingEffect.SetActive(false);
                }
            }
        }
    }

    public void TurnOnCoverEffect()
    {
        _coverEffect.SetActive(true);
    }

    public float CriticalHit(float currentAttackDamage)
    {
        // randomly checks to see if you landed a crit
        int critHit = Random.Range(critRate, 100);

        Debug.Log("CRITICAL HIT Damage " + (currentAttackDamage += Mathf.RoundToInt(currentAttackDamage * critDamagemultipler)));

        // if crit hits, then current attack will be multiplied by crit damage modifer
        if (critHit <= critRate)
            currentAttackDamage += Mathf.RoundToInt(currentAttackDamage * critDamagemultipler);

        return currentAttackDamage;
    }
}
