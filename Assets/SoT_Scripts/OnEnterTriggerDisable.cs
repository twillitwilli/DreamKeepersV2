using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoT.Classes
{
    public class OnEnterTriggerDisable : MonoBehaviour
    {
        [SerializeField]
        string _tagToLookFor;

        [SerializeField]
        GameObject[] _disableObjects;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == _tagToLookFor)
                foreach (var obj in _disableObjects)
                    obj.SetActive(false);
        }
    }
}

