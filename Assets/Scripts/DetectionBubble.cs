using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;
using System.Linq;

[RequireComponent(typeof(CircleCollider2D))]
public class DetectionBubble : MonoBehaviour
{
    public string DesiredTag = "Building";
    public bool Detecting;
    public float Radius = 1.0f;

    public List<Collider2D> detected = new List<Collider2D>();

    private void Start()
    {
        var collider = GetComponent<CircleCollider2D>();
        collider.radius = Radius;
        collider.isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        detected.SafeAdd(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detected.SafeRemove(collision);
    }


    public void Update()
    {
        Detecting = detected.Any(s => s.gameObject.tag == DesiredTag);
    }
}
