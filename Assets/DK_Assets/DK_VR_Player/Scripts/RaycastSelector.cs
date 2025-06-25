using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    [SerializeField]
    LayerMask _ignoreLayers;

    [SerializeField]
    GameObject _rayEffect;

    private UIIinput _input;

    private void FixedUpdate()
    {
        RaycastHit hit;
        // sets the direction and length of the ray cast
        Vector3 forward = transform.TransformDirection(Vector3.up) * 5;

        // shoots ray cast
        if (Physics.Raycast(transform.position, forward, out hit, 5, -_ignoreLayers))
        {

            // new input variable
            UIIinput newInput;

            // checks to see if ray hit a gameobject with the UIInput component and set to new variable
            // if the ray hits one
            if (hit.collider.gameObject.TryGetComponent<UIIinput>(out newInput))
            {
                Debug.Log("ray hit");

                // if ray is hitting a UI element, the ray effect will turn on to show players what they
                // are selecting
                _rayEffect.SetActive(true);

                // checks to see if the ray already has an input selected or not
                if (_input == null)
                {
                    _input = newInput;
                    _input.HighLightInput();
                }

                else if (_input != newInput)
                {
                    _input.DeselectInput();
                    _input = newInput;
                    _input.HighLightInput();
                }
            }

            // if ray doesnt hit any UI elements, turns off ray effect if not already disabled
            else
            {
                _rayEffect.SetActive(false);

                // checks to see if there is an existing input selected and if so deselects it
                if (_input != null)
                {
                    _input.DeselectInput();
                    _input = null;
                }
            }
        }

        //Debug.DrawRay(transform.position, forward);
    }
}
