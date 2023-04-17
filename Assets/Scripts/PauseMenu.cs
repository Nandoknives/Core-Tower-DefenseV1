using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public SceneFader sceneFacer;
    private int escCounter = 0;
    public string menuSceneName = "MainMenu";
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            escCounter++;
            if (escCounter == 2)
            {
                Toggle();
                escCounter = 0;
            }
            else
            {
                StartCoroutine(PauseMenuV());
            }
            
            

        }

        
    }
    IEnumerator PauseMenuV()
    {
        
        ui.SetActive(!ui.activeSelf);
        yield return new WaitForSeconds(0.7f);
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;


        }
        else
        {
            Time.timeScale = 1f;
        }
        
    }
    public void Toggle()
    {

        ui.SetActive(!ui.activeSelf);
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
            

        }
        else
        {
            Time.timeScale = 1f;
        }
        escCounter = 0;
    }

    public void Retry()
    {
        Toggle();
        sceneFacer.FadeTo(SceneManager.GetActiveScene().name);
       

    }

    public void Menu()
    {
        Toggle();
        sceneFacer.FadeTo(menuSceneName);
    }
}
