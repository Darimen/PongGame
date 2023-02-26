using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject menu;
    public GameObject options;

    public void Start()
    {
        //menu.SetActive(true);
        options.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    

    public void Quit()
    {
        Application.Quit();
    }
}
