using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimatorBool : StateMachineBehaviour
{
    public string isInteractingBool = "isInteracting";
    public bool isInteractingStatus = false;

    public string isFiringBool = "isFiring";
    public bool isFiringStatus = false;

    public string canDoCombo = "canDoCombo";
    public bool comboStatus = false;



    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(isInteractingBool, isInteractingStatus);
        animator.SetBool(isFiringBool, isFiringStatus);
        animator.SetBool(canDoCombo, comboStatus);
    }
}
