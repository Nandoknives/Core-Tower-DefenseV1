using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayCastPower: MonoBehaviour
{
    
    public GameObject satellitebeam;
    public GameObject beamExplosion;
    public bool isSelected=true;
    BuildManager buildManager;
    public float explosionRadius = 10f;
    public int damage = 50;
    public int energyCost = 20;
    public AudioSource click;
    public AudioSource error;

    public TMP_Text clockText;
    public bool fired = false;
    public CountDownBeam countDown1;
    public Messages messageEnergy;

    //Cooldown Test
    public float cooldownTime = 5;
    private float nextFireTime = 0;
    private float temporalCoolDown;
    

    public bool HasEnergy { get { return PlayerStats.Energy>= energyCost; } }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RayCastPower>().enabled = false;
        buildManager = BuildManager.instance;
        fired = false;
        temporalCoolDown = cooldownTime;
        clockText.enabled = false;

    }
       
    // Update is called once per frame
    void Update()
    {
        isSelected = true;
        if (Time.time>nextFireTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                

                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                if (HasEnergy)
                {
                    
                    TurnOnCountB();
                    clockText.enabled = true;
                    StartCoroutine(CastSatelliteBeam());
                    PlayerStats.Energy -= energyCost;
                    Debug.Log("Enegry Left: " + PlayerStats.Energy);
                    nextFireTime = Time.time + cooldownTime;
                    
                }
                else
                {
                    error.Play();
                    NoEnergyMessage();
                    Debug.Log("No Energy!!!");
                }
            }
        }
        if(fired==true)
        {
            cooldownTime -= Time.deltaTime;
            cooldownTime = Mathf.Clamp(cooldownTime, 0f, Mathf.Infinity);
            clockText.text = Mathf.Round(cooldownTime).ToString();
            if(cooldownTime ==0f)
            {
                fired = false;
                cooldownTime = temporalCoolDown;
                clockText.enabled=false;
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            DisableSatelliteBeam();
        }
    }
    void TurnOnCountB()
    {
        CountDownBeam c = countDown1.GetComponent<CountDownBeam>();
        c.fired1 = true;
    }
    void NoEnergyMessage()
    {
        Messages e = messageEnergy.GetComponent<Messages>();
        e.noEnergy = true;
    }
    public bool GetStateBool()
    {
        return isSelected;
    }
    public IEnumerator CastSatelliteBeam()
    {
        
        Vector3 mousePos = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            
            GameObject beamEffect = Instantiate(satellitebeam, hit.point, Quaternion.identity);
            Destroy(beamEffect, 5.0f);
            yield return new WaitForSeconds(2.6f);
            GameObject expEffect = Instantiate(beamExplosion, hit.point, Quaternion.identity);
            Destroy(expEffect, 5.0f);
            Collider[] colliders = Physics.OverlapSphere(hit.point, explosionRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("SEnemy"))
                {

                    Damage(collider.transform);

                }
            }


        }
        isSelected = true;

    }
   
    public void EnableSatelliteBeam()
    {
        click.Play();
        buildManager.DeselectNode();
        GetComponent<RayCastPower>().enabled = true;
        isSelected = true;
                        
    }
    public void DisableSatelliteBeam()
    {
        isSelected = false;        
        GetComponent<RayCastPower>().enabled = false;
                        
    }
    void Damage(Transform enemy)
    {

        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);

        }


    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

    }


}
