using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject sword;
    public Animator animator;

    public float speed = 100f;



    void Update()
    {
        
    }

    public void RotateSword()
    {
        animator.Play("HoverRotate");
    }

    public void StopRotateSword()
    {
        animator.SetTrigger("Stop");
    }


}
