﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    void Update()
    {
        
    }

    public void ToPlay()
    {
        StartCoroutine(LoadLevel("Tutorial"));
    }

    public void ToCredits()
    {
        StartCoroutine(LoadLevel("Credits"));
    }

    public void ToArena()
    {
        StartCoroutine(LoadLevel("Arena1"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(string LevelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(LevelName);
    }
}
