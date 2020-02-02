using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmGrabber : MonoBehaviour
{
   
    public Animator Animator;

    // Update is called once per frame
    void Update()
    {
        Animator.SetBool("Close", Input.GetMouseButton(0));
    }
}
