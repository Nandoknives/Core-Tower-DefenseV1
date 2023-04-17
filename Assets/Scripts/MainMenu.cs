using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";

    public SceneFader sceneFader;
    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
        
    }
    public void Quit()
    {
        Debug.Log("I got bored!!!");
        Application.Quit();
    }
    private void Awake()
    {
        Time.timeScale = 1f;
    }
}
