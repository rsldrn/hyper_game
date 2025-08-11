using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour // buradaki get componentler metod icinde kalirsa sikinti olur mu
{
    [Header("Elements")]
    [SerializeField] private Transform runnerParent;
    public void Run()
    {
        for (int i = 0; i < runnerParent.childCount; i++)
        {
            Transform runner = runnerParent.GetChild(i);
            Animator runnerAnimator = runner.GetComponent<Animator>();
            runnerAnimator.Play("Run");
        }
    }
    
    public void Idle()
    {
        for (int i = 0; i < runnerParent.childCount; i++)
        {
            Transform runner = runnerParent.GetChild(i);
            Animator runnerAnimator = runner.GetComponent<Animator>();
            runnerAnimator.Play("Idle");
        }
    }
}





