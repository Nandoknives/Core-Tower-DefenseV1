using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public TMP_Text upgradeCost;
    public TMP_Text upgradeCost1;
    public TMP_Text upgradeName1;
    public TMP_Text upgradeName2;
    public Transform cameraTarget;



    private FixedJoint turretjoint;
    private Rigidbody targetjoint;

    public Button upgradeButton;
    public Button upgradeButton1;

    public bool upgradeBlocked=true;
    public bool upgrade1Blocked=true;

    public TMP_Text sellAmount;

    private Node target;
    private void Start()
    {
        
        Hide();
        
    }
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        if (upgradeBlocked == true)
        {
            upgradeButton.interactable = false;
            upgradeCost.text = "Locked";
        }
        if (upgrade1Blocked == true)
        {
            upgradeButton1.interactable = false;
            upgradeCost1.text = "Locked";
        }
        if (!target.isUpgraded)
        {
            if (upgradeBlocked == true)
            {
                upgradeButton.interactable = false;
                upgradeCost.text = "Locked";
            }
            else
            {
                upgradeName1.text = target.turretBluePrint.upgrade2;
                upgradeCost.text = "$" + target.turretBluePrint.upgradeCost;
                upgradeButton.interactable = true;
                
            }
            if (upgrade1Blocked == true)
            {
                upgradeButton1.interactable = false;
                upgradeCost1.text = "Locked";
            }
            else
            {
                upgradeName2.text = target.turretBluePrint.upgrade3;
                upgradeCost1.text = "$" + target.turretBluePrint.upgradeCost1;
                upgradeButton1.interactable = true;
            }
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeCost1.text = "DONE";
            upgradeButton.interactable = false;
            upgradeButton1.interactable = false;
        }

        sellAmount.text = "$" + target.turretBluePrint.GetSellAmount();
        ui.SetActive(true);
        Debug.Log("Showing Upgrade Menu");
        
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    // Start is called before the first frame update

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode(); 
    }

    public void Upgrade1()
    {
        target.UpgradeTurret1();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraTarget);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Node")
        {
            Debug.Log("Conection!");
            targetjoint = collision.rigidbody;
            Debug.Log("Target Joint" + targetjoint);
            turretjoint.connectedBody = targetjoint;
            Debug.Log("Connected to: " + turretjoint.connectedBody);
        }
    }
}
