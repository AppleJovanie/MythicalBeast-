using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class animatorController : MonoBehaviour
{
    private Animator _animator;

    //private void Awake()
    //{
    //    _animator.GetComponent<Animator>();
    //}
    private void PlayIdle()
    {
        _animator.Play("Idle");
    }
    public void PlayRun ()
    {
        _animator.Play("Run");
    }
}
