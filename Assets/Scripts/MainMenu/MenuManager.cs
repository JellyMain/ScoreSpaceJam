using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private static string _sceneName = "MainScene";
    private static string _mainMenuName= "MainMenu";

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_sceneName);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_mainMenuName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
