using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{
    public float Frequency = 500;
    public Transform Source;
    public Rigidbody2D SourceRb;

    public RelativeJoint2D FixedJoint;

    public void Start()
    {
        var target = GetComponent<Rigidbody2D>();
        if(target == null)
        {
            Destroy(this);
            return;
        }

        FixedJoint = target.gameObject.AddComponent<RelativeJoint2D>();
        FixedJoint.autoConfigureOffset = false;
        FixedJoint.connectedBody = SourceRb;
                //FixedJoint.anchor = transform.localPosition - target.transform.position;
        //FixedJoint.distance = 1;
        //FixedJoint.autoConfigureDistance = false;

    }

    //private void FixedUpdate()
    //{
    //    FixedJoint.linearOffset = Source.position;
    //}

    private void OnDestroy()
    {
        if(FixedJoint != null)
        {
            Destroy(FixedJoint);
        }
    }
}
