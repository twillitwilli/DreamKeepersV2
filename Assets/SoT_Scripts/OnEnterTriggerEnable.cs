using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoT.Classes
{
    public class OnEnterTriggerEnable : MonoBehaviour
    {
        [SerializeField]
        string _tagToLookFor;

        [SerializeField]
        GameObject[] _enableObjects;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == _tagToLookFor)
                foreach (var obj in _enableObjects)
                    obj.SetActive(true);
        }
    }
}
