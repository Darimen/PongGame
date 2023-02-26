using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionMenu;

    private static bool isPaused;
    // Update is called once per frame
    private void Start()
    {
        optionMenu.SetActive(false);
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
    void Update()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            optionMenu.SetActive(false);
            pauseMenu.SetActive(true);
            Debug.Log("pause");
            isPaused = true;
        }
        else if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            optionMenu.SetActive(false);
            pauseMenu.SetActive(false);
            Debug.Log("unpause");
            isPaused = false;
        }
    }

    public static bool getPause()
    {
        return isPaused;
    }
}
