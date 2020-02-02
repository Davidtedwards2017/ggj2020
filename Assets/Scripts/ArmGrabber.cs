using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmGrabber : MonoBehaviour
{
    private AudioSource mySource;
    [SerializeField] AudioClip myClip;
    public Animator Animator;


    private void Start()
    {
        mySource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Animator.SetBool("Close", Input.GetMouseButton(0));
        if (Input.GetMouseButtonDown(0))
        {
            mySource.PlayOneShot(myClip);
        }
    }
}
