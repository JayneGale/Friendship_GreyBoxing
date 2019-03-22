using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public KeyCode pauseMenuKey;
    public static PauseMenu instance = null;
    public GameObject pauseMenu;
    private bool paused;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(pauseMenuKey))
        {
            print("pausingNow");
            paused = !paused;
        }

        if (paused == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GameResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }


    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}

