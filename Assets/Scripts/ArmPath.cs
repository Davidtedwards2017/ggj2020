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

    public float inputCooldown = 0.1f;
    public float cooldown;

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
            return;
        }

        if(Input.GetKey(KeyCode.A))
        {
            step = Mathf.Clamp(step - Speed * Time.deltaTime, 0, 1);
            SetPosition(step);
            cooldown = inputCooldown;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            step = Mathf.Clamp(step + Speed * Time.deltaTime, 0, 1);

            SetPosition(step);
            cooldown = inputCooldown;
        }
    }

    void SetPosition(float step)
    {
        var position = Vector3.Lerp(StartAnchor.transform.position, EndAnchor.transform.position, step);
        ArmGameObject.transform.position = position;
    }
}
