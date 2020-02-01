using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ArmPath : MonoBehaviour
{

    public GameObject ArmGameObject;
    public DOTweenPath Path;
    public int Current = 0;
    private int length;

    public float inputCooldown = 0.1f;
    public float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        Path = GetComponent<DOTweenPath>();
        length = Path.wps.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            return;
        }

        if(Input.GetKey(KeyCode.A))
        {
            Current = Mathf.Clamp(Current + 1, 0, length);
            SetPosition(Current);
            cooldown = inputCooldown;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            Current = Mathf.Clamp(Current - 1, 0, length);
            SetPosition(Current);
            cooldown = inputCooldown;
        }
    }

    void SetPosition(int index)
    {
        if(ArmGameObject != null)
        {
            ArmGameObject.transform.position = Path.wps[index];
        }
    }
}
