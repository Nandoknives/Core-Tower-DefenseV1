using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;

    public void Continue()
    {
        Debug.Log("LEVEL WON!");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        Time.timeScale = 1f;
        sceneFader.FadeTo(nextLevel);
        
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
        Time.timeScale = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
