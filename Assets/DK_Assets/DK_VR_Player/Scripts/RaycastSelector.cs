using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    [SerializeField]
    LayerMask _ignoreLayers;

    [SerializeField]
    GameObject _rayEffect;

    private void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.up) * 5;

        if (Physics.Raycast(transform.position, forward, out hit, 5, -_ignoreLayers))
        {
            UIIinput uiInput;

            if (hit.collider.gameObject.TryGetComponent<UIIinput>(out uiInput))
            {
                Debug.Log("ray hit");
                _rayEffect.SetActive(true);
            } 

            else _rayEffect.SetActive(false);
        }

        //Debug.DrawRay(transform.position, forward);
    }
}
