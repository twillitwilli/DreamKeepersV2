using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoT.AbstractClasses;

public class SceneEventTriggers : MonoSingleton<SceneEventTriggers>
{
    public EventTriggerData[] eventTriggers;

    public bool[] completedEvents;
}
