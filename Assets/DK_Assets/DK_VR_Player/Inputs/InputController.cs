using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class InputController : MonoBehaviour
{
    PlayerController _playerController;

    VRHandController
        _leftHandController,
        _rightHandController;

    PlayerControls _playerControls;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _leftHandController = _playerController.leftHand.GetComponent<VRHandController>();
        _rightHandController = _playerController.rightHand.GetComponent<VRHandController>();
    }

    private void Start()
    {
        _playerControls = new PlayerControls();
    }

    void OnJump()
    {
        _playerController.Jump();
    }

    void OnMovement(InputValue value)
    {
        Vector2 movementVector = value.Get<Vector2>();

        _playerController.Movement(movementVector);
    }

    void OnRotation(InputValue value)
    {
        Vector2 rotationVector = value.Get<Vector2>();

        _playerController.Rotation(rotationVector);
    }

    void OnDash()
    {
        _playerController.Dash();

        Debug.Log("Dash");
    }

    void OnCrouch()
    {
        bool crouch = _playerController.isCrouched ? false : true;
        _playerController.isCrouched = crouch;

        Debug.Log("is crouched = " + _playerController.isCrouched);
    }

    void OnSprint()
    {
        _playerController.Sprint();

        Debug.Log("Sprinting On");
    }

    void OnGrabLeft(InputValue value)
    {
        bool grabbing = value.Get<float>() == 0 ? false : true;

        _leftHandController.TogglePhysicalGrabTrigger(grabbing);
    }

    void OnGrabRight(InputValue value)
    {
        bool grabbing = value.Get<float>() == 0 ? false : true;

        _rightHandController.TogglePhysicalGrabTrigger(grabbing);
    }

    void OnTriggerLeft(InputValue value)
    {
        bool grabbing = value.Get<float>() == 0 ? false : true;

        _leftHandController.GrabObject(grabbing);
    }

    void OnTriggerRight(InputValue value)
    {
        bool grabbing = value.Get<float>() == 0 ? false : true;

        _rightHandController.GrabObject(grabbing);
    }

    void OnMenu()
    {
        Debug.Log("Menu");
    }
}
