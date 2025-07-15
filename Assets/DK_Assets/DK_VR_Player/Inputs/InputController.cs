using System;
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

    // Event Controller For Inputs

    // These delegates and events work the same as the action, but the action is just
    // faster readibly for common commands

    //public delegate void releasegrableft(bool islefthand);
    //public delegate void releasegrabright(bool islefthand);
    //public static event releasegrableft onreleasegrableft;
    //public static event releasegrabright onreleasegrabright;

    // The delegates and events are better to use for less common or more complex functions
    public static Action<bool> leftGripReleased;
    public static Action<bool> rightGripReleased;

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

        // trigger grab release event
        if (!grabbing)
            leftGripReleased(true);
    }

    void OnTriggerRight(InputValue value)
    {
        bool grabbing = value.Get<float>() == 0 ? false : true;

        _rightHandController.GrabObject(grabbing);

        // trigger grab release event
        if (!grabbing)
            rightGripReleased(false);
    }

    void OnMenu()
    {
        Debug.Log("Menu");
    }
}
