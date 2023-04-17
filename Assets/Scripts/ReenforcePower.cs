using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReenforcePower: MonoBehaviour
{
    
    public GameObject invincibilitybeam;
    public bool isSelected=true;
    BuildManager buildManager;
    public int energyCost = 20;
    public int radiousEffect;

    //Cooldown Test
    public float cooldownTime = 5;
    private float nextFireTime = 0;
    

    public bool HasEnergy { get { return PlayerStats.Energy>= energyCost; } }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ReenforcePower>().enabled = false;
        buildManager = BuildManager.instance;

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
                    StartCoroutine(Reeforce());
                    PlayerStats.Energy -= energyCost;
                    Debug.Log("Enegry Left: " + PlayerStats.Energy);
                    nextFireTime = Time.time + cooldownTime;
                }
                else
                {
                    Debug.Log("No Energy!!!");
                }
            }
        }
        
        if(Input.GetButtonDown("Fire2"))
        {
            DisableReeforce();
        }
    }
    public bool GetStateBool()
    {
        return isSelected;
    }
    public IEnumerator Reeforce()
    {
        
        Vector3 mousePos = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            
            GameObject beamEffect = Instantiate(invincibilitybeam, hit.point, Quaternion.identity);
            Destroy(beamEffect, 5.0f);
            yield return new WaitForSeconds(2.6f);
            Collider[] colliders = Physics.OverlapSphere(hit.point, radiousEffect);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("SEnemy"))
                {

                    

                }
            }


        }
        isSelected = true;

    }

   
    public void EnableReeforce()
    {
        buildManager.DeselectNode();
        GetComponent<ReenforcePower>().enabled = true;
        isSelected = true;
                        
    }
    public void DisableReeforce()
    {
        isSelected = false;        
        GetComponent<ReenforcePower>().enabled = false;
                        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiousEffect);

    }


}
