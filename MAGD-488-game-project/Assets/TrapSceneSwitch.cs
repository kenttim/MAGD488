using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSceneSwitch : MonoBehaviour
{

    LevelLoader levelLoader;

    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        levelLoader.ToArena();
    }
}
