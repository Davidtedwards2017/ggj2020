using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Stage))]
public class StageInEditor : Editor
{
    public float Angle = 90;
    public float TorqueOffset = 5000;
    public float Power = 500000;
    public float PowerOffset = 10000;


    public override void OnInspectorGUI()
    {
        Stage myScript = (Stage)target;
        if(GUILayout.Button("Scatter"))
        {
            myScript.Scatter(Angle, Power - PowerOffset, Power + PowerOffset, -TorqueOffset, TorqueOffset);
        }

        base.OnInspectorGUI();
    }
}
