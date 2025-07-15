using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDummy : MonoBehaviour
{
    private void OnDestroy()
    {
        Debug.Log("WTF, you killed the dummy!!!???");
    }
}
