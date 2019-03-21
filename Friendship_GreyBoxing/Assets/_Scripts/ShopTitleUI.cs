using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopTitleUI : MonoBehaviour {

    public void ShopPlay()
    {
        SceneManager.LoadScene("Workingscene");
    }

    public void ShopControls()
    {
        SceneManager.LoadScene("ShoppingControls");
    }

    public void ShopTitle()
    {
        SceneManager.LoadScene("ShoppingTitle");
    }

    public void ShopQuit()
    {
        Application.Quit();
    }
}
