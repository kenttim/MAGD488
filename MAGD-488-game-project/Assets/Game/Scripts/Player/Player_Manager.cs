using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Manager : MonoBehaviour
{
    #region Singleton

    public static Player_Manager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
