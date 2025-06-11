using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySaveStats : MonoBehaviour
{
    [SerializeField]
    int _saveFile;

    [SerializeField]
    Text _text;

    [SerializeField]
    GameObject _portal;

    private void Start()
    {
        BinarySaveData loadedData = BinarySaveSystem.LoadData(_saveFile);

        if (loadedData != null)
        {
            _text.text = "Save File #" + _saveFile + "\n" + loadedData.playerName;
            _portal.SetActive(true);
        }

        else _portal.SetActive(false);
    }
}
