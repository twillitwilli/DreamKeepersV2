using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisableTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject[] _disableObjects;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player;

        // Checks to see if the player entered the trigger, if so disables all gameobjects in array
        if (other.TryGetComponent<PlayerController>(out player))
            foreach (var obj in _disableObjects)
                obj.SetActive(false);
    }
}
