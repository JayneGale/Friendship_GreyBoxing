using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopPause : MonoBehaviour {

    public static ShopPause instance = null;

    public GameObject pauseMenu;
    private bool paused;
    public bool isAlive = true;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isAlive == true)
        {
            paused = !paused;
        }

        if(paused == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            AlpaconMove.instance._isPaused = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            AlpaconMove.instance._isPaused = false;
        }
    }

    public void ShopResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        paused = false;
        AlpaconMove.instance.canMove = true;
    }

    public void ShopRetry()
    {
        Time.timeScale = 1;
        AlpaconMove.instance.canMove = true;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ShopTitle()
    {
        Time.timeScale = 1;
        AlpaconLives.instance.livesLost = 0;
        SceneManager.LoadScene("ShoppingTitle");
    }

}
