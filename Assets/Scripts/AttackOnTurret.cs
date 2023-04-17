using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AttackOnTurret : MonoBehaviour
{
    private Transform target;
    private Turret targetTurret;

    [Header("Cannon Setup")]
    public float range = 10f;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0;
    public float fireRate1 = 1f;
    private float fireCountdown1 = 0;
    public string enemyTag = "Turret";
    public Transform partToRotate;
    public float turnSpeed = 5f;
    public Transform firePoint;
    public Transform firePoint1;
    public ParticleSystem muzzleFlash;
    [SerializeField] private AudioSource fire;
    Vector3 initialPos;
    Quaternion initialRot;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        initialRot = transform.rotation; 
        initialPos = transform.position;    

    }
    void Update()
    {
        if (target==null)
        {
            LockInFront();
            return;
        }
        LockOnTarget();
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
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetTurret = nearestEnemy.GetComponent<Turret>();
        }
        else
        {
            target = null;
            
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();
        fire.Play();
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);        
        Bullet bullet = bulletGO.GetComponent<Bullet>();       
        if (bullet != null)
        {
            bullet.Seek(target);
        }


    }
    void Shoot1()
    {
        muzzleFlash.Play();
        fire.Play();
        GameObject bulletGO1 = (GameObject)Instantiate(bulletPrefab, firePoint1.position, firePoint.rotation);
        Bullet bullet1 = bulletGO1.GetComponent<Bullet>();
        if (bullet1 != null)
        {
            bullet1.Seek(target);
        }
    }
    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

    }
    void LockInFront()
    {
        
        Quaternion lookRotation = initialRot;
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
  

}
