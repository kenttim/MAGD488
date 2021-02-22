using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_Modified : MonoBehaviour
{

    #region Singleton

    public static PlayerManager_Modified instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    InputHandler inputHandler;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        inputHandler = player.GetComponent<InputHandler>();
        anim = player.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHandler.isInteracting = anim.GetBool("isInteracting");
        inputHandler.rollFlag = false;
    }
}
