using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void NormalMode()
    {
        Time.timeScale = 1f;
        Player.score = 0;
        SceneManager.LoadScene("Lv1");
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

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
