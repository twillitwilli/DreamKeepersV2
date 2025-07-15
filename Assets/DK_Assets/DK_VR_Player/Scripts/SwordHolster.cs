using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHolster : MonoBehaviour
{
    [SerializeField]
    Transform _swordPosition;

    private void Start()
    {
        InputController.leftGripReleased += HolsterSword;
        InputController.rightGripReleased += HolsterSword;
    }

    private void OnTriggerEnter(Collider other)
    {
        Sword newSword;

        if (other.gameObject.TryGetComponent<Sword>(out newSword))
        {
            // check when current hand that is not holding sword is not holding grab
        }
    }

    public void HolsterSword(bool isLeftHand)
    {
        if (isLeftHand)
            Debug.Log("left hand released grip");

        else
            Debug.Log("right hand release grip");
    }

    public void LoadSword()
    {

    }
}