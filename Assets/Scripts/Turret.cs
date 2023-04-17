using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;
    public NodeUI nodeUI;
    private FixedJoint turretjoint;
    private Rigidbody targetjoint;
    public bool rage = false;
    public bool heal = false;
    public GameObject healingSign;
    public GameObject rageSign;

    [Header("Turret Status")]
    public float startHealth = 100;
    public float maxhealth;
    private float health;
    public GameObject deathEffect;
    private bool isdead = false;
    public bool isRaged = false;

    [Header("General")]
    public float range =15f;

    public AudioSource laserFire;

    [Header("Unity Stuff")]

    public Image healthBar;

    [Header("Use Bullets(default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float fireRate1 = 1f;
    private float initialFirerate;
    private float initialFirerate1;
    public float fireRateRage = 2.5f;
    private float fireCountdown = 0;
    private float fireCountdown1 = 0;
    public float multRage = 1f;
    public float multRage1 = 1f;

    [Header("Use Laser")]
    public bool useLaser = false;

    public float damageOverTime = 30;
    private float initialDamageOverTime;
    public float laserRageDamage = 50; 
    public float slowAmount = 0.5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    

    [Header("Unity Setup Fields")]
    public string enemyTag = "SEnemy";
    public Transform partToRotate;
    public float turnSpeed = 5f;
        
    public Transform firePoint;
    public Transform firePoint1;




    // Start is called before the first frame update
    void Start()
    {
        initialFirerate = fireRate;
        initialFirerate1 = fireRate1;
        initialDamageOverTime = damageOverTime;
        isRaged = false;
        health = startHealth;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        InvokeRepeating("AttackSpeed", 0f, 0.5f);
        InvokeRepeating("Calm", 0.1f, 3f);
        InvokeRepeating("NotHeal", 0.1f, 3f);

        healthBar.fillAmount = health;
        turretjoint = gameObject.GetComponent<FixedJoint>();
        healingSign.GetComponent<MeshRenderer>().enabled = false;
        rageSign.GetComponent<MeshRenderer>().enabled = false;

    }


    void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy<shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy!=null && shortestDistance<= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target=null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(heal==true)
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
        if(isRaged==true)
        {
            if (rageSign == null)
            {
                return;
            }
            else
            {
                rageSign.GetComponent<MeshRenderer>().enabled = true;
            }
            
 
        }
        else
        {
            if (rageSign == null)
            {
                return;
            }
            else
            {
                rageSign.GetComponent<MeshRenderer>().enabled = false;
            }
            
        }

        if (target == null)
        {
            if(useLaser)
            {
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    laserFire.Stop();
                    
                }
            }
            return;
        }
        LockOnTarget();
        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
                if (firePoint1 != null)
                {
                    Shoot1();
                    fireCountdown1 = 1f / fireRate1;
                }


            }
            fireCountdown -= Time.deltaTime;
            
        }
        

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Node")
        {
            Debug.Log("Conection!");
            targetjoint = collision.rigidbody;
            Debug.Log("Target Joint"+ targetjoint);
            turretjoint.connectedBody = targetjoint;
            Debug.Log("Connected to: " + turretjoint.connectedBody);
        }
    }
    void Laser()
    {
      
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            laserFire.Play();
            
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
        impactEffect.transform.position = target.position + dir.normalized ;
        impactEffect.transform.position = target.position;
    }
    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

    }
    void AttackSpeed()
    {
        if(isRaged==false)
        {
            fireRate = initialFirerate;
            fireRate1 = initialFirerate1;
            damageOverTime = initialDamageOverTime;
        }
        else
        {
            fireRate = multRage;
            fireRate1 = multRage1;
            damageOverTime = laserRageDamage;
        }

    }
    void Calm()
    {
        isRaged = false;
    }
    void NotHeal()
    {
        heal = false;
    }
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        laserFire.Play();
        if(bullet != null)
        {
            bullet.Seek(target);
        }
        
    }

    void Shoot1()
    {
        
        
        GameObject bulletGO1 = (GameObject)Instantiate(bulletPrefab, firePoint1.position, firePoint.rotation);
        Bullet bullet1 = bulletGO1.GetComponent<Bullet>();
        laserFire.Play();
        if (bullet1 != null)
        {
            bullet1.Seek(target);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        
    }
    public void TakeDamage(float amount)
    {
        Debug.Log("Damage Taken");
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        
        if (health <= 0 && !isdead)
        {
            Die();
        }
    }
    public void HealDamage(float amount)
    {
        heal = true;
        if (health + amount>maxhealth)
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
    void Die()
    {
        isdead = true;
        
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
                
        Destroy(gameObject);
        


    }
}
