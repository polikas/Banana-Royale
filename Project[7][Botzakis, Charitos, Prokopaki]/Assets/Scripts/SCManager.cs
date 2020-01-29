using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SCManager : MonoBehaviour
{
   public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadGamePlay()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void loadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void closeApp()
    {
        Application.Quit();
    }
}
