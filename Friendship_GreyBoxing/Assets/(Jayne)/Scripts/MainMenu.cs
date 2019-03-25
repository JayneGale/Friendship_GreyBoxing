using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Midnight");
    }

    public void ReallyQuit()
    {
        if (Application.isEditor)
        {
            print("Quit pressed, exiting Play mode");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }


}
