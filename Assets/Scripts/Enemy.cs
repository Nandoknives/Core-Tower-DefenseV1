using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{


    public float startSpeed;
    [HideInInspector]
    public float speed;
    public float slowedSpeed=1f;
    
    public float startHealth = 100;
    private float health;

    public int worth = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")]

    public Image healthBar;
    private bool isdead = false;

    


    void Start()
    {
        NavMeshAgent e = this.GetComponent<NavMeshAgent>();
        startSpeed=e.speed;
        health = startHealth;
        healthBar.fillAmount = health;
        InvokeRepeating("NormalSpeed", 1f, 5f);
        
    }
    void NormalSpeed()
    {
        NavMeshAgent e = this.GetComponent<NavMeshAgent>();
        if (e != null)
        {
            e.speed = startSpeed;
        }
    }

    

    // Start is called before the first frame update


    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health/startHealth;

        if(health<=0 &&!isdead)
        {
            Die();
        }
    }
    public void Slow()
    {
        NavMeshAgent e = this.GetComponent<NavMeshAgent>();
        if(e != null)
        {
            e.speed = slowedSpeed;
        }
        
    }
    void Die()
    {
        isdead = true;
        PlayerStats.Money += worth;
        

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;
        WinConditions.totalEnemies--;
        WinConditions.enemiesKilled++;
        
        
        Destroy(gameObject);



    }

    // Update is called once per frame

}
