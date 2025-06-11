using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DalamikPlayerControls : MonoBehaviour
{
    [SerializeField]
    Text _text;

    public BoxCollider gameTrigger { get; private set; }
    public DalamikPlayer dalamikPlayer { get; set; }

    private void Awake()
    {
        Debug.Log("Roll not implemented, finger trigger to trigger it was removed");

        gameTrigger = GetComponent<BoxCollider>();
        gameTrigger.enabled = false;
    }

    public void Roll()
    {
        dalamikPlayer.roll = true;

        gameTrigger.enabled = false;
    }

    public void ChangeTextDisplay(string newText)
    {
        _text.text = newText;
    }
}
