using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{


    public static int EnemiesAlive = 0;
    
    public Waves[] waves;
        
    public Transform spawnPoint;
    
    public float timeBetweenWaves = 1f;
    
    private float countdown = 1f;
    
    public Text waveCountdownText;
    
    private int waveIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Waves wave = waves[waveIndex];



        WinConditions.totalEnemies += waves[waveIndex].count*2;
    }
    // Update is called once per frame
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        
        if (waveIndex == waves.Length)
        {
            WinConditions.spawnerCounter++;
            Debug.Log("Waves Defeated: " + WinConditions.spawnerCounter);
            this.enabled = false;
     
        }
      
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
    
        countdown -= Time.deltaTime;
      
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
   
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
   
    }
    
   
    IEnumerator SpawnWave()
    {
        
        PlayerStats.Rounds++;
        Waves wave = waves[waveIndex];
       
        Debug.Log("waves.Length = " + waves.Length );
        EnemiesAlive = wave.count;
        
           
        for (int i = 0; i < wave.count; i++)
        {

            SpawnEnemy(wave.enemy);
            
            yield return new WaitForSeconds(1f/wave.rate);

        }
        
        waveIndex++;
         
        Debug.Log("waveIndex = " + waveIndex );
  
    }
    
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    
    }
    



}
