using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmExtenstion : MonoBehaviour
{
    public float MaxExtension = 10;
    public float MinExtention = 0;
    public float CurrentExtention;

    public float ExtendRate = 2.0f;
    public float TimeBeforeDecay = 0.1f;
    public float DecayRate = 1;

    public float CurrentStep = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
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
        var distance = Mathf.Lerp(MinExtention, MaxExtension, step);
        transform.localPosition = new Vector3(-distance, 0);
    }
}
