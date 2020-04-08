using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public void ToLv1()
    {
        Time.timeScale = 1f;
        Player.score = 0;
        SceneManager.LoadScene("Lv1");
    }

    public void ToLv2()
    {
        Time.timeScale = 1f;
        Player.score = 0;
        SceneManager.LoadScene("Lv2");
    }

    public void ToLv3()
    {
        Time.timeScale = 1f;
        Player.score = 0;
        SceneManager.LoadScene("Lv3");
    }

    public void EndlessMode()
    {
        Time.timeScale = 1f;
        Player.score = 0;
        SceneManager.LoadScene("EndlessGameMode");
    }

    public void GoHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Credits()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
