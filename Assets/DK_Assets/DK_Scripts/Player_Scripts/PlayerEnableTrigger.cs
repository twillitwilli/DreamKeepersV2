using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnableTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject[] _enableObjects;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player;

        // Checks to see if the player entered the trigger, if so enables all gameobjects in array
        if (other.TryGetComponent<PlayerController>(out player))
            foreach (var obj in _enableObjects)
                obj.SetActive(true);
    }
}
