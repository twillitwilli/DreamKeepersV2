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

    [SerializeField]
    MeshRenderer _renderer;

    public void InputKey()
    {
        switch (inputType)
        {
            case InputType.InputLetter:

                _textDisplay.text += _keypadEntry;

                break;

            case InputType.BackSpace:

                _textDisplay.text = _textDisplay.text.Substring(0, _textDisplay.text.Length - 1);

                break;

            case InputType.ToggleObjects:

                if (_toggleObjectsOn.Length > 0)
                    foreach (GameObject obj in _toggleObjectsOn) obj.SetActive(true);

                if (_toggleObjectsOff.Length > 0)
                foreach (GameObject obj in _toggleObjectsOff) obj.SetActive(false);

                break;

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
        if (_renderer != null)
            _renderer.enabled = true;
    }

    public void DeselectInput()
    {
        if (_renderer != null)
            _renderer.enabled = false;
    }
}