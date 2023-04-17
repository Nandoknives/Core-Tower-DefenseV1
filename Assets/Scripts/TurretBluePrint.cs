using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]

public class TurretBluePrint {

    public GameObject prefab;
    public string upgrade1;
    public string upgrade2;
    public string upgrade3;

    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public GameObject upgradedPrefab1;
    public int upgradeCost1;

    public int GetSellAmount()
    {
        return cost / 2;
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
