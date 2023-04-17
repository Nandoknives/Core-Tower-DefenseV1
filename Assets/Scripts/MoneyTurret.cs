using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTurret : MonoBehaviour
{
    private FixedJoint turretjoint;
    private Rigidbody targetjoint;
    public GameObject healingSign;
    public bool heal = false;

    private Transform target;
    private Enemy targetEnemy;

    [Header("Turret Status")]
    public float startHealth = 100;
    public float maxhealth;
    private float health;
    public GameObject deathEffect;
    private bool isdead = false;

    [Header("General")]
    public float range =15f;

    [Header("Unity Stuff")]

    public Image healthBar;

    public int energyPerSecond = 5;
    public float generationRate = 1;
    public int moneyPerSecond = 5;
    private int timeA=0;
    private int timeAlive;


    private void Awake()
    {
        turretjoint = gameObject.GetComponent<FixedJoint>();

    }


    // Start is called before the first frame update
    void Start()
    {
        healingSign.GetComponent<MeshRenderer>().enabled = false;
        health = startHealth;
        InvokeRepeating("NotHeal", 0.1f, 3f);
        healthBar.fillAmount = health;
        StartCoroutine(GenerateEnergy());
        

    }
   
    // Update is called once per frame
    void Update()
    {
        if (heal == true)
        {
            if (healingSign == null)
            {
                return;
            }
            else
            {
                healingSign.GetComponent<MeshRenderer>().enabled = true;
            }

        }
        else
        {
            if (healingSign == null)
            {
                return;
            }
            else
            {
                healingSign.GetComponent<MeshRenderer>().enabled = false;
            }

        }


    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Node")
        {
            Debug.Log("Conection!");
            targetjoint = collision.rigidbody;
            Debug.Log("Target Joint" + targetjoint);
            turretjoint.connectedBody = targetjoint;
            Debug.Log("Connected to: " + turretjoint.connectedBody);
        }
    }
    IEnumerator GenerateEnergy()
    {
        while (true)
        {
            PlayerStats.Energy += energyPerSecond;
            PlayerStats.Money += moneyPerSecond;
            
            yield return new WaitForSeconds(generationRate);
        }
        
        
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isdead)
        {
            Die();
        }
    }
    void Die()
    {
        isdead = true;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);



    }
    void NotHeal()
    {
        heal = false;
    }
    public void HealDamage(float amount)
    {
        heal = true;
        if (health + amount > maxhealth)
        {
            float rest = maxhealth - health;
            health += rest;
            healthBar.fillAmount = health / startHealth;
            Debug.Log("Current Health" + health);
        }
        else
        {
            health += amount;


            healthBar.fillAmount = health / startHealth;
            Debug.Log("Current Health" + health);
        }





    }


}
