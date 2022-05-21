using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneManager : MonoBehaviour
{
    public void moveToLevel1()
    {
        SceneManager.LoadScene(sceneName:"Level1");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
