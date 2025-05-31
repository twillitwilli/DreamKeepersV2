using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    BoxCollider _swordTrigger;

    [SerializeField]
    GameObject
        _swingEffect,
        _coverEffect;

    public VRHandController currentHand { get; set; }

    public List<Vector3> handTrackingPositions = new List<Vector3>();

    private async void Update()
    {
        if (currentHand != null)
        {
            if (!currentHand.trackHandVelocity)
                currentHand.trackHandVelocity = true;

            // tracking hand velocity
            else
            {
                handTrackingPositions = currentHand._handTrackingPos;

                Vector3 direction = handTrackingPositions[handTrackingPositions.Count - 1] - handTrackingPositions[0];

                float swordVelocity = Vector3.Magnitude(direction * 2000);

                Debug.Log("sword velocity = " + swordVelocity);

                if (swordVelocity > 1000)
                {
                    // Sword Swing Attack
                    _swordTrigger.isTrigger = true;

                    // Turn On Swing Effect
                    _swingEffect.SetActive(true);
                }

                else if (_swordTrigger.isTrigger)
                {
                    // Turn off Sword Swing Attack
                    _swordTrigger.isTrigger = false;

                    // wait half a second
                    await Task.Delay(500);

                    // turn off swing effect
                    _swingEffect.SetActive(false);
                }
            }
        }
    }

    public void TurnOnCoverEffect()
    {
        _coverEffect.SetActive(true);
    }
}
