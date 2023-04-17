using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed =70f;
    public int damage = 50;
    public float explosionRadius = 10f;
    public GameObject impactEffect;


    public void Seek(Transform _target)
    {
        target = _target;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectIns =(GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 4f);

        if(explosionRadius > 0f)
        {
            Explode();

         
        }
        else
        {
            Damage(target);
            DamageTurret(target);
            DamageETurret(target);
            DamageSTurret(target);
        }
           
        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.CompareTag("SEnemy"))
            {
                Damage(collider.transform);
                
            }
        }
    }
    void Damage(Transform enemy)
    {
        
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
            
        }
        
        
    }
    void DamageTurret(Transform enemy)
    {
        Turret t = enemy.GetComponent<Turret>();
        if(t !=null)
        {
            t.TakeDamage(damage);
        }

    }
    void DamageETurret(Transform enemy)
    {
        EnergyTurret c = enemy.GetComponent<EnergyTurret>();
        if (c != null)
        {
            c.TakeDamage(damage);
        }

    }
    void DamageSTurret(Transform enemy)
    {
        SupportTurret c = enemy.GetComponent<SupportTurret>();
        if (c != null)
        {
            c.TakeDamage(damage);
        }

    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
        
    }
}
