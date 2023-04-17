using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver ;

    public GameObject gameOverUI;

    public GameObject completeLevelUI;

    public Waves[] waves;

    public AudioSource ambientAudio;

    public AudioSource loseAudio;



    private void Awake()
    {
        GameObject menuMusic = GameObject.FindGameObjectWithTag("MenuMusic");
        Destroy(menuMusic);
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameIsOver = false;
        ambientAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
   

        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }
        if (Input.GetKeyDown("e"))
        {
            StartCoroutine(EndGameV());
        }
        if (Input.GetKeyDown("y"))
        {
            StartCoroutine(WinLevelV());
        }
        if (PlayerStats.Lives <=0)
        {
            StartCoroutine(EndGameV());
        }
        
    }
    IEnumerator EndGameV()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
        ambientAudio.Stop();
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
    }
    public IEnumerator WinLevelV()
    {
        gameIsOver = true;
        completeLevelUI.SetActive(true);
        ambientAudio.Stop();
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
    }
    public void WinLEvel()
    {
        gameIsOver = true;
        completeLevelUI.SetActive(true);
        ambientAudio.Stop();
        Time.timeScale = 0f;



    }
}
