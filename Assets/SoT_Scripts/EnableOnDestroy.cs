using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoT.Classes
{
    public class EnableOnDestroy : MonoBehaviour
    {
        [SerializeField]
        GameObject[] _objectsToEnable;

        private void OnDestroy()
        {
            foreach (GameObject obj in _objectsToEnable)
                obj.SetActive(true);
        }
    }
}
