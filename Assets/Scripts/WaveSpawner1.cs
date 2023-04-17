using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner1 : MonoBehaviour
{


    
    public static int EnemiesAlive1 = 0;
   
    public Waves1[] waves1;
        
    public Transform spawnPoint1;
    
    public float timeBetweenWaves1 = 5f;
    
    private float countdown1 = 1f;

    
        
    public Text waveCountdownText1;
    
    private int waveIndex1 = 0;


    // Start is called before the first frame update
    void Start()
    {
        Waves1 wave1 = waves1[waveIndex1];



        WinConditions.totalEnemies += waves1[waveIndex1].count * 2;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (EnemiesAlive1>0)
        {
            return;
        }
        
        if (waveIndex1 == waves1.Length)
        {
            WinConditions.spawnerCounter++;
            Debug.Log("Waves Defeated: " + WinConditions.spawnerCounter);
            
        }
     
        if (countdown1<=0f)
        {
            StartCoroutine(SpawnWave1());
            countdown1 = timeBetweenWaves1;
            return;
        }
        
        countdown1 -= Time.deltaTime;
        
        countdown1 = Mathf.Clamp(countdown1, 0f, Mathf.Infinity);
        
        waveCountdownText1.text = string.Format("{0:00.00}", countdown1);

    }

    IEnumerator SpawnWave1()
    {

        PlayerStats.Rounds++;

        Waves1 wave1 = waves1[waveIndex1];


        EnemiesAlive1 = wave1.count;

        for (int j = 0; j < wave1.count; j++)
        {

            SpawnEnemy1(wave1.enemy);
            yield return new WaitForSeconds(1f / wave1.rate);
        }
        
        waveIndex1++;

    }

    void SpawnEnemy1(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint1.position, spawnPoint1.rotation);

    }
}
