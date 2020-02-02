using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public List<BuildingPiece> Pieces;
    public DetectorArea DetectorArea;

    public void Scatter(float randomAngle, float minPower, float maxPower, float minTorque, float maxTorque)
    {
        foreach(var piece in Pieces)
        {
            var angle = Mathf.Lerp(90 - randomAngle / 2, 90 + randomAngle / 2, (float)Random.Range(0.0f, 1.0f));
            Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, angle) * Vector2.right);
            var power = Mathf.Lerp(minPower, maxPower, ((float)Random.Range(0.0f, 1.0f)));

            Debug.Log(string.Format("Power: {0} direction: {1}", power, dir));
            piece.Rb.AddRelativeForce(dir * power);

            var torque = Mathf.Lerp(minTorque, maxTorque, Random.Range(0.0f, 1.0f));
            piece.Rb.AddTorque(torque);
        }
    }
}
