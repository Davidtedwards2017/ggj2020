using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;
public class StartStep : MonoBehaviour
{
    public SoundEffectData stepSound;
    public Animator frontanimator;
    public Animator backanimator;

    public void StartStepBack()
    {
        
        backanimator.SetBool("walk", true);
    }

    public void StartStepFront()
    {
        frontanimator.SetBool("walk", true);
    }


    public void StopStepBack()
    {

        backanimator.SetBool("walk", false);
    }

    public void StopStepFront()
    {
        frontanimator.SetBool("walk", false);
    }

    public void PlayStep()
    {
        stepSound.PlaySfx();
    }
}
