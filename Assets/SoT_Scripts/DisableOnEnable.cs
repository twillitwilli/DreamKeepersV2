using UnityEngine;

namespace SoT.Classes
{
    public class DisableOnEnable : MonoBehaviour
    {
        [SerializeField]
        GameObject[] _disableObjects;

        void OnEnable ()
        {
            foreach (GameObject obj in _disableObjects) obj.SetActive(false);
        }
    }
}
