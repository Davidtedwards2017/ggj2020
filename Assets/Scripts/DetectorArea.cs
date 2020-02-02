using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DetectorArea : MonoBehaviour
{
    public int Total;
    public int Filled;
    public float Percent;

    private DetectionBubble[] Detectors
    {
        get { return GetComponentsInChildren<DetectionBubble>(); }
    }

    // Update is called once per frame
    void Update()
    {
        var detectors = Detectors;
        Total = detectors.Length;
        Filled = detectors.Count(d => d.Detecting);
        Percent = ((float)Filled / ((float)Total));
}
}
