using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmGrabber : MonoBehaviour
{

    public Transform OpenAnchor;
    public Transform ClosedAnchor;

    public float ExtendRate = 2.0f;
    public float TimeBeforeDecay = 0.1f;
    public float DecayRate = 1;
    public float CurrentStep = 0;

    public GameObject Hand;

    private void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CurrentStep += ExtendRate * Time.deltaTime;
            CurrentStep = Mathf.Clamp(CurrentStep, 0, 1);
            SetArmExtention(CurrentStep);
        }
        else
        {
            CurrentStep -= ExtendRate * Time.deltaTime;
            CurrentStep = Mathf.Clamp(CurrentStep, 0, 1);
            SetArmExtention(CurrentStep);
        }
    }

    public void SetArmExtention(float step)
    {
        var newPos = Vector3.Lerp(OpenAnchor.localPosition, ClosedAnchor.localPosition, step);
        Hand.transform.localPosition = newPos;
    }
}
