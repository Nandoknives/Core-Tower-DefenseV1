using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinConditions : MonoBehaviour
{
    public GameManager gameManager;
    public static int spawnerCounter=0;       
    public int spawners=2;
    public static int totalIndex = 0;
    public int numberOfEnemies;
    public static int totalEnemies;
    public AudioSource winAudio;
    public static int enemiesKilled;
 


    // Start is called before the first frame update
    void Start()
    {
        totalEnemies = numberOfEnemies;
        enemiesKilled = 0;
 
        
        
    }

    // Update is called once per frame

    void Update()
    {
        if (totalEnemies <= 0)
        {
            StartCoroutine(gameManager.WinLevelV());

            
        }
        Debug.Log("Total Enemies = " + totalEnemies);
    }
  

}
