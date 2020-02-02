using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleExplosion : MonoBehaviour

{
    public Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Explode();
    }

    void Explode()
    {
        transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), transform.eulerAngles.z);
        float speed = 700;
        rigidBody.isKinematic = false;
        Vector3 force = transform.forward;
        force = new Vector3(force.x, 3, force.z);
        rigidBody.AddForce(force * speed);
    }
}
