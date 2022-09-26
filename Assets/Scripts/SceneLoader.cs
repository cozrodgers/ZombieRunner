using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {

        Scene currentScene = SceneManager.GetSceneByBuildIndex(0);
        SceneManager.LoadScene(currentScene.buildIndex);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
