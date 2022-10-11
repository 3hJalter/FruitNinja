using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    public void ExitButton()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void StarButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("MenuScene");
    }
}
