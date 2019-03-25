using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Midnight");
        Time.timeScale = 1;
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
