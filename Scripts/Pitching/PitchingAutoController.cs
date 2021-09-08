using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchingAutoController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ThrowAnimation()
    {
        animator.SetBool("Pitching", true);
    }

    public void IdleAnimation()
    {
        animator.SetBool("Pitching", false);
    }
}
