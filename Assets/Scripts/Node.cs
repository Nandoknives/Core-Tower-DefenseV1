using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public TMP_Text messageText;
    public float cooldownTimeMess = 3f;
    private float temporalCoolDownMess;
    public bool noMoney;
    public AudioSource error;

    public Color hoverColor;
    public Color notEnoughtMoneyColor;
    public Vector3 positionOffset;
    public Messages messageEnergy;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded;
    public RayCastPower raycastpower;
    private static bool check = true;


    private Renderer rend;
    private Color startColor;
        

    BuildManager buildManager;

    void Awake()
    {
        
    }
    void Start()
    {
        temporalCoolDownMess = cooldownTimeMess;
        messageText.enabled = false;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;

        noMoney = false;
        
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown()
    {
        
        
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.SelectNode(this);

            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        
        buildManager.BuildTurretOn(this);
        BuildTurret(buildManager.GetTurretToBuild());
        
    }
   
    void BuildTurret(TurretBluePrint bluePrint)
    {

        if (PlayerStats.Money < bluePrint.cost)
        {
            error.Play();
            noMoney = true;
            NoMoneyMessage();
            
            Debug.Log("Not enough money to Build Tower!");
            return;
        }
        
        PlayerStats.Money -= bluePrint.cost;


        GameObject _turret = (GameObject)Instantiate(bluePrint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBluePrint = bluePrint;
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = false;

        Debug.Log("Turret Build!, Money Left: " + PlayerStats.Money);
    }
    void NoMoneyMessage()
    {
        
        messageText.enabled = true;
        cooldownTimeMess -= Time.deltaTime;
        cooldownTimeMess = Mathf.Clamp(cooldownTimeMess, 0f, Mathf.Infinity);
        messageText.text = "Not Enough Money!!!";
        if (cooldownTimeMess == 0f)
        {


            messageText.enabled = false;
            cooldownTimeMess = temporalCoolDownMess;
            noMoney = false;
        }
    }
    public void SellTurret()
    {
        PlayerStats.Money += turretBluePrint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBluePrint = null;
    }

    public void UpgradeTurret()
    {

        if (PlayerStats.Money < turretBluePrint.upgradeCost)
        {
            noMoney = true;
            NoMoneyMessage();
            Debug.Log("Not enough money to Upgrade Tower!");
            return;
        }
        PlayerStats.Money -= turretBluePrint.upgradeCost;

        //Get rid of the old turret
        Destroy(turret);

        //Build a new one
        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
        Debug.Log("Turret Upgraded!, Money Left: " + PlayerStats.Money);
    }

    public void UpgradeTurret1()
    {

        if (PlayerStats.Money < turretBluePrint.upgradeCost1)
        {
            Debug.Log("Not enough money to Upgrade Tower!");
            return;
        }
        PlayerStats.Money -= turretBluePrint.upgradeCost1;

        //Get rid of the old turret
        Destroy(turret);

        //Build a new one
        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgradedPrefab1, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
        Debug.Log("Turret Upgraded!, Money Left: " + PlayerStats.Money);
    }

    void OnMouseEnter()
    {
        
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(!buildManager.CanBuild)
        {
            return;
        }
        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
       
        else
        {
            rend.material.color = notEnoughtMoneyColor;
        }
        
     }

    void OnMouseExit()
    {
        rend.material.color = startColor;
        
    }
        
    // Update is called once per frame
    void Update()
    {
       if(noMoney==true)
        {
            NoMoneyMessage();
        }
    }
    
}
