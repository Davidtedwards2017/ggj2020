using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float speed = 10;
    public float MinWorldY = 10;

    // Update is called once per frame
    void Update()
    {
        var pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;
        pos.y = Mathf.Max(pos.y, MinWorldY);
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
    }
}
