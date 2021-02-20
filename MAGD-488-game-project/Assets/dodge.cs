using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodge : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    public float DelayIFrames = 0.2f;
    public float iFrames = 0.5f;

    public float dodgeCoolDown = 1;
    public float actCoolDown;

    public float pushAmt = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool roll = Input.GetKeyDown(KeyCode.LeftShift);
        if (actCoolDown <= 0)
        {
            anim.ResetTrigger("Roll");
            if (roll)
            {
                Dodge();
            }
        } else
        {
            actCoolDown -= Time.deltaTime;
        }


    }

    void Dodge()
    {
        actCoolDown = dodgeCoolDown;

        rb.AddForce(transform.forward * pushAmt, ForceMode.Force);

        anim.SetTrigger("Roll");
    }
}
