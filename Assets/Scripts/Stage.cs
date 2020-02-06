using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class Stage : MonoBehaviour
{
    public enum States
    {
        Unfilled,
        Filled,
        Win
    }

    [Range(0,1)]
    public float FilledPercentTarget = 0.87f;
    public float StablizingTime = 3;

    public List<BuildingPiece> Pieces;
    public DetectorArea DetectorArea;

    public Color DetectorFilledColor;
    public Color DetectorUnFilledColor;

    public StateMachine<States> stateCtrl;

    public void Awake()
    {
        stateCtrl = StateMachine<States>.Initialize(this);
    }

    public void Init()
    {
        stateCtrl.ChangeState(States.Unfilled);
    }

    public void Scatter(float randomAngle, float minPower, float maxPower, float minTorque, float maxTorque)
    {
        foreach(var piece in Pieces)
        {
            var angle = Mathf.Lerp(90 - randomAngle / 2, 90 + randomAngle / 2, (float)Random.Range(0.0f, 1.0f));
            Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, angle) * Vector2.right);
            var power = Mathf.Lerp(minPower, maxPower, ((float)Random.Range(0.0f, 1.0f)));

            piece.Rb.AddRelativeForce(dir * power);

            var torque = Mathf.Lerp(minTorque, maxTorque, Random.Range(0.0f, 1.0f));
            piece.Rb.AddTorque(torque);
        }
    }

    public void Unfilled_Enter()
    {
        Debug.Log("UnFilled");
        DetectorArea.SetFilledOutline(false);
    }

    public void Unfilled_Update()
    {
        if (!Input.GetMouseButton(0) && DetectorArea.Percent >= FilledPercentTarget)
        {
            stateCtrl.ChangeState(States.Filled);
        }
    }

    Coroutine _stabilizing;
    public void Filled_Enter()
    {
        Debug.Log("Filled");
        DetectorArea.SetFilledOutline(true);
        _stabilizing = StartCoroutine(Stablizing());
    }

    private IEnumerator Stablizing()
    {
        float duration = StablizingTime;

        while(duration > 0)
        {
            yield return new WaitForEndOfFrame();
            duration -= Time.deltaTime;
        }

        stateCtrl.ChangeState(States.Win);
    }

    public void Filled_Update()
    {
        if (Input.GetMouseButton(0) || DetectorArea.Percent < FilledPercentTarget)
        {
            stateCtrl.ChangeState(States.Unfilled);
        }
    }

    public void Filled_Exit()
    {
        if(_stabilizing != null)
        {
            StopCoroutine(_stabilizing);
        }
    }

    public void Win_Enter()
    {
        Debug.Log("Win");
        GameStateController.Instance.Win();
    }

}
