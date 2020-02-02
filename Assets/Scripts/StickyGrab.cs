using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class StickyGrab : MonoBehaviour
{
    public bool Active = true;
    public List<Collision2D> InArea = new List<Collision2D>();
    public Rigidbody2D rb;

    //public Collision Grab
    Collider Grabbed;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Grabbed!");
            if (other.gameObject.Get<Sticky>() != null) return;
            var sticky = other.gameObject.AddComponent<Sticky>();
            sticky.Source = transform;
            sticky.SourceRb = rb;
        }
        else
        {
            var sticky = other.gameObject.Get<Sticky>();
            if (sticky != null)
            {
                Destroy(sticky);
            }
        }
    }
    
}
