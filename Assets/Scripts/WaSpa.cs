using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaSpa : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 3f;
    public float waveCountdown;

    private float searchCountdown = 1f;
    public float DelayofnextWave;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No Spawn Points");
        }

        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if(state==SpawnState.WAITING)
        {
            if(!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if(waveCountdown<=0)
        {
            if (state!= SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }
    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Completed all Waves!!!");
        }
        else
        {
            nextWave++;
        }
    }
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown<=0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("SEnemy") == null)
            {
                return false;
            }
            else
            {
                
            }
        }
        return true;
        
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        
        Debug.Log("Spawning Wave : " + _wave.name);
        state = SpawnState.SPAWNING;

        for(int i=0;i<_wave.count;i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f /_wave.rate);
        }

        state = SpawnState.WAITING;
        yield return new WaitForSeconds(DelayofnextWave);
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy: " + _enemy.name);

       
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
        
    }
        
}
