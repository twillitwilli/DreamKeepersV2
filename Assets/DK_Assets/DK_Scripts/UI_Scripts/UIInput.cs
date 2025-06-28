using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIIinput : MonoBehaviour
{
    public enum InputType
    {
        InputLetter,
        BackSpace,
        ToggleObjects,
        SavePlayerName
    }

    public InputType inputType;

    [SerializeField]
    string _keypadEntry;

    [SerializeField]
    Text _textDisplay;

    [SerializeField]
    GameObject[]
        _toggleObjectsOff,
        _toggleObjectsOn;

    MeshRenderer _renderer;

    private void Start()
    {
        // Checks to see if this object has a Mesh Renderer, and if it does sets the _renderer reference
        if (TryGetComponent<MeshRenderer>(out _renderer)) { }
    }

    public void InputKey()
    {
        switch (inputType)
        {
            // adds typed letter to a text display
            case InputType.InputLetter:

                _textDisplay.text += _keypadEntry;

                break;

            // deletes the last character of a text display
            case InputType.BackSpace:

                _textDisplay.text = _textDisplay.text.Substring(0, _textDisplay.text.Length - 1);

                break;

            // toggles all objects on and off depending on which array they are in
            case InputType.ToggleObjects:

                if (_toggleObjectsOn.Length > 0)
                    foreach (GameObject obj in _toggleObjectsOn) obj.SetActive(true);

                if (_toggleObjectsOff.Length > 0)
                foreach (GameObject obj in _toggleObjectsOff) obj.SetActive(false);

                break;

            // SPECIAL USE CASE - this is only for saving the player name in the title screen, once the player name
            // is saved it will disable the keypad and enable the portal to enter a new game
            case InputType.SavePlayerName:

                PlayerController.Instance.playerStats.stats.playerName = _textDisplay.text;

                if (_toggleObjectsOn.Length > 0)
                    foreach (GameObject obj in _toggleObjectsOn) obj.SetActive(true);

                if (_toggleObjectsOff.Length > 0)
                foreach (GameObject obj in _toggleObjectsOff) obj.SetActive(false);

                break;
        }
    }

    public void HighLightInput()
    {
        // turns on the mesh renderer if it exists
        if (_renderer != null)
            _renderer.enabled = true;
    }

    public void DeselectInput()
    {
        // turns off the mesh renderer if it exists
        if (_renderer != null)
            _renderer.enabled = false;
    }
}