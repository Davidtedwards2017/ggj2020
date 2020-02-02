using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotator : MonoBehaviour
{
    public float Speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(new Vector3(0, 0, 1), Speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.C))
        {
            transform.Rotate(new Vector3(0, 0, 1), -Speed * Time.deltaTime);
        }
    }
}
