using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicAnimations : MonoBehaviour
{
    Animator anim;
    SonicController sonic;
    void Start()
    {
        anim = GetComponent<Animator>();
        sonic = GetComponent<SonicController>();
    }

    void Update()
    {
        if (sonic.isJumping)
            anim.Play("Jump");
        else if (sonic.isBrake)
            anim.Play("Brake");
        else if (sonic.isRun)
            anim.Play("Run");
        else if (sonic.isWalk)
            anim.Play("Walk");
        else if (sonic.isIdle)
            anim.Play("Idle");
    }
}
