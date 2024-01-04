using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    private const int IDLE_ANIMATION = 0;
    const int RUN_ANIMATION = 1;
    [SerializeField]private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayRunAnimation(){
        animator.SetInteger("transition",RUN_ANIMATION);
    }
    public void PlayIdleAnimation(){
        animator.SetInteger("transition",IDLE_ANIMATION);
    }
    public void PlayPunchAnimation(){
        animator.SetTrigger("tgrPunch");
    }
}
