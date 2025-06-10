using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    public enum InputType
    {
        InputLetter,
        BackSpace,
        ChangeLetterCase,
        Save
    }

    public InputType inputType;

    [SerializeField]
    string _keypadEntry;

    [SerializeField]
    Text _textDisplay;

    [SerializeField]
    bool
        isBackSpace,
        isChangeLetterCase,
        isSave;

    public void InputKey()
    {
        switch (inputType)
        {
            case InputType.InputLetter:

                _textDisplay.text += _keypadEntry;

                break;

            case InputType.BackSpace:

                

                break;

            case InputType.ChangeLetterCase:

                

                break;

            case InputType.Save:

                

                break;
        }

        
    }
}
