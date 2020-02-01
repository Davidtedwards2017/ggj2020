using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ArmPath : MonoBehaviour
{

    public GameObject StartAnchor;
    public GameObject EndAnchor;
    
    public GameObject ArmGameObject;
    public float Speed = 1;
    public float step = 0;

    public float inputCooldown = 0.01f;
    public float cooldown;

    public float transitionSpeed = 5;
    public Vector3 TargetPos;

    // Start is called before the first frame update
    void Start()
    {
        SetPosition(step);
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                step = Mathf.Clamp(step - Speed * Time.deltaTime, 0, 1);
                cooldown = inputCooldown;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                step = Mathf.Clamp(step + Speed * Time.deltaTime, 0, 1);
                cooldown = inputCooldown;
            }
        }

        SetPosition(step);
        ArmGameObject.transform.position = Vector3.Lerp(ArmGameObject.transform.position, TargetPos, Time.deltaTime * transitionSpeed);
    }

    void SetPosition(float step)
    {
        TargetPos = Vector3.Lerp(StartAnchor.transform.position, EndAnchor.transform.position, step);
    }
}
