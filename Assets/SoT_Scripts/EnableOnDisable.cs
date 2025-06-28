using UnityEngine;

namespace SoT.Classes
{
    public class EnableOnDisable : MonoBehaviour
    {
        [SerializeField]
        GameObject[] _enableObjects;

        private void OnDisable()
        {
            foreach (GameObject obj in _enableObjects) obj.SetActive(true);
        }
    }
}
