using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreenModule : Module
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected override void OnActivated()
    {
        animator.SetBool("Show", true);
        base.OnActivated();
    }

    protected override void OnDeactivated()
    {
        animator.SetBool("Show", false);
        base.OnDeactivated();
    }
}
