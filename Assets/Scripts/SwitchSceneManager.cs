using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneManager : MonoBehaviour
{
    [SerializeField] string nameOfNextScene;
    public void moveToLevel()
    {
        SceneManager.LoadScene(nameOfNextScene);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void moveToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
}
