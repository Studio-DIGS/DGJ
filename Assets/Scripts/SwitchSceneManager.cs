using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneManager : MonoBehaviour
{
    [SerializeField] string nameOfNextScene;
    public void moveToLevel()
    {
        SceneManager.LoadSceneAsync(sceneName: nameOfNextScene);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void moveToMainMenu()
    {
        SceneManager.LoadSceneAsync(sceneName: "MainMenu");
    }
}
