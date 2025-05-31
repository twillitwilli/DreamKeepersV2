using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public EventTriggerData triggerData;

    public List<GameObject>
        enableObjs,
        disableObjs;

    [Header("For Scene Loading")]
    public List<GameObject> loadObjs;
    public List<GameObject> removeObjs;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player;

        // if player enters trigger, will trigger the event
        if (other.gameObject.TryGetComponent<PlayerController>(out player))
        {
            EventTriggered();
        }
    }

    public void EventTriggered()
    {
        // if there are objects to enable during the event being triggered
        if (enableObjs.Count > 0)
            foreach (GameObject obj in enableObjs)
                obj.SetActive(true);

        // if there are objects to disable during the event being triggered
        if (disableObjs.Count > 0)
            foreach (GameObject obj in disableObjs)
                obj.SetActive(false);

        // disables gameObject after active
        gameObject.SetActive(false);
    }

    public void LoadEvent()
    {
        // if there are objects that will be loaded upon entering the scene
        if (loadObjs.Count > 0)
            foreach (GameObject obj in loadObjs)
                obj.SetActive(true);

        // if there are objects that will be removed upon entering the scene
        if (removeObjs.Count > 0)
            foreach (GameObject obj in removeObjs)
                obj.SetActive(false);

        // disable gameobject after active
        gameObject.SetActive(false);
    }
}
