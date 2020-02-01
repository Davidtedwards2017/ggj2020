using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmExtenstion : MonoBehaviour
{
    public float MaxExtension = 10;
    public float MinExtention = 0;
    public float CurrentExtention;

    public float step = 0;
    public float Speed = 1;
    public float inputCooldown = 0.1f;
    public float cooldown;

    public float transitionSpeed = 1;

    public Vector3 TargetPos;


    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                step = Mathf.Clamp(step - Speed * Time.deltaTime, 0, 1);
                cooldown = inputCooldown;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                step = Mathf.Clamp(step + Speed * Time.deltaTime, 0, 1);
                cooldown = inputCooldown;
            }
        }

        SetArmExtention(step);
        transform.localPosition = Vector3.Lerp(transform.localPosition, TargetPos, Time.deltaTime * transitionSpeed);
    }

    public void SetArmExtention(float step)
    {
        var distance = Mathf.Lerp(MinExtention, MaxExtension, step);
        TargetPos = new Vector3(-distance, 0);
    }

}
