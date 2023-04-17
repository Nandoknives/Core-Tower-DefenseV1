using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShop : MonoBehaviour
{
    public PowersBluePrint satelliteBeam;
    

    BuildManager buildManager;
    void Start()
    {
        
    }


    public void SelectSatelliteBeam()
    {

        Debug.Log("Satellite Beam Selected");
        buildManager.SelectPowerToCast(satelliteBeam);
    }

    
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }
}
