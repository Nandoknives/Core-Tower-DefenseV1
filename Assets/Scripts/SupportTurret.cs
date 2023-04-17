using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupportTurret: MonoBehaviour
{
    private FixedJoint turretjoint;
    private Rigidbody targetjoint;
    [Header("Turret Status")]
    public float startHealth = 100;
    public float maxhealth;
    private float health;
    public GameObject deathEffect;
    private bool isdead = false;
    

    [Header("Unity Stuff")]

    public Image healthBar;
       
    public float healingRadius;
    public int healthRecover;
    public int energyCost;



    private void Awake()
    {
        turretjoint = gameObject.GetComponent<FixedJoint>();

    }

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;

        healthBar.fillAmount = health;
        StartCoroutine(HealTurrets());
        

    }
   
    // Update is called once per frame
    void Update()
    {

        
        
        
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
    IEnumerator HealTurrets()
    {
        while (true)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, healingRadius);
            
            foreach (Collider collider in colliders)
            {

                if (collider.CompareTag("Turret"))
                {
                    
                    Heal(collider.transform);
                    HealE(collider.transform);
                    HealEM(collider.transform);
                    HealLU(collider.transform);
                    Debug.Log("Healing Towers");
                    

                }
            }
            
            yield return new WaitForSeconds(1f);
        }
        
       


    }
    void Heal(Transform enemy)
    {

        Turret c = enemy.GetComponent<Turret>();
        if (c != null)
        {          
            if (PlayerStats.Energy >= 0)
            {
                if (PlayerStats.Energy - energyCost <= 0)
                {
                    return;
                }
                else
                {
                    c.HealDamage(healthRecover);
                    PlayerStats.Energy -= energyCost;
                    Debug.Log("Current Energy: " + PlayerStats.Energy);
                }
            }
            else
            {
                return;
            }
        }
    }

    void HealE(Transform enemy)
    {
        EnergyTurret e = enemy.GetComponent<EnergyTurret>();
        if (e != null)
        {
            if (PlayerStats.Energy >= 0)
            {
                if (PlayerStats.Energy - energyCost <= 0)
                {
                    return;
                }
                else
                {
                    e.HealDamage(healthRecover);
                    PlayerStats.Energy -= energyCost;
                    Debug.Log("Current Energy: " + PlayerStats.Energy);
                }
            }
            else
            {
                return;
            }
        }
    }
    void HealLU(Transform enemy)
    {
        LaserUpgrade e = enemy.GetComponent<LaserUpgrade>();
        if (e != null)
        {
            if (PlayerStats.Energy >= 0)
            {
                if (PlayerStats.Energy - energyCost <= 0)
                {
                    return;
                }
                else
                {
                    e.HealDamage(healthRecover);
                    PlayerStats.Energy -= energyCost;
                    Debug.Log("Current Energy: " + PlayerStats.Energy);
                }
            }
            else
            {
                return;
            }
        }
    }

    void HealEM(Transform enemy)
    {
        MoneyTurret e = enemy.GetComponent<MoneyTurret>();
        if (e != null)
        {
            if (PlayerStats.Energy >= 0)
            {
                if (PlayerStats.Energy - energyCost <= 0)
                {
                    return;
                }
                else
                {
                    e.HealDamage(healthRecover);
                    PlayerStats.Energy -= energyCost;
                    Debug.Log("Current Energy: " + PlayerStats.Energy);
                }
            }
            else
            {
                return;
            }
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
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, healingRadius);

    }
   
    public void HealDamage(float amount)
    {
        
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
