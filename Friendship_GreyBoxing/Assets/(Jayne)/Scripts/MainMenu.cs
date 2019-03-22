using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public KeyCode pauseMenuKey = KeyCode.P;
    public KeyCode quitMenuKey = KeyCode.Escape;
    public KeyCode jumpMenuKey = KeyCode.Space;
    public KeyCode RunMenuKey = KeyCode.LeftShift;
    public KeyCode Run2MenuKey = KeyCode.RightShift;

    public void PlayGame()
    {
        SceneManager.LoadScene("Midnight");
    }

    public void ReallyQuit()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }


}
