using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PowersBluePrint 
{
    public GameObject prefab;
    public int costEnergy;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return costEnergy / 2;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
