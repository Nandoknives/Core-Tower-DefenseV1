using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Berserk : MonoBehaviour
{

    public GameObject berserkBeam;
    public bool isSelected = true;
    BuildManager buildManager;
    public int energyCost = 20;
    public int radiousRage;
    private float initialSpeed;
    public AudioSource click;
    public AudioSource error;
    public CountDownBeam countDown1;
    public Messages messageEnergy;

    //Cooldown Test
    public float cooldownTime = 5;
    private float nextFireTime = 0;


    public bool fired = false;
    private float temporalCoolDown;


    public bool HasEnergy { get { return PlayerStats.Energy >= energyCost; } }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Berserk>().enabled = false;
        buildManager = BuildManager.instance;
        fired = false;
        temporalCoolDown = cooldownTime;

    }

    // Update is called once per frame
    void Update()
    {
        isSelected = true;
        if (Time.time > nextFireTime)
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
                    StartCoroutine(Enrage());
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

        if (Input.GetButtonDown("Fire2"))
        {
            DisableBerserk();
        }
    }

    void TurnOnCountB()
    {
        CountDownBeam c = countDown1.GetComponent<CountDownBeam>();
        c.fired3=true;
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
    public IEnumerator Enrage()
    {

        Vector3 mousePos = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {

            GameObject beamEffect = Instantiate(berserkBeam, hit.point, Quaternion.identity);
            Destroy(beamEffect, 10.0f);
            Collider[] colliders = Physics.OverlapSphere(hit.point, radiousRage);
            while (beamEffect == true)
            {              
                foreach (Collider collider in colliders)
                {
                    Rage(collider.transform);
                    
                }
                yield return new WaitForSeconds(1f);
                
            }
            foreach (Collider collider in colliders)
            {
                Calm(collider.transform);

            }
            yield return new WaitForSeconds(10f);
        }
        isSelected = true;
      

    }

    void Rage(Transform enemy)
    {

        NavMeshAgent c = enemy.GetComponent<NavMeshAgent>();
        if (c != null)
        {
            initialSpeed = c.speed;
            c.speed = 1f;
            Debug.Log("SlowingEnemies");
        }
    }

    void Calm(Transform enemy)
    {

        NavMeshAgent c = enemy.GetComponent<NavMeshAgent>();
        if (c != null)
        {
            c.speed=initialSpeed;
            
        }
    }

    public void EnableBerserk()
    {
        click.Play();
        buildManager.DeselectNode();
        GetComponent<Berserk>().enabled = true;
        isSelected = true;

    }
    public void DisableBerserk()
    {
        isSelected = false;
        GetComponent<Berserk>().enabled = false;

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiousRage);

    }


}
