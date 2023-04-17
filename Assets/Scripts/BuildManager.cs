using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance!= null)
        {
            Debug.LogError("More than one Building Manager in scene!");
            return;
        }
        instance = this;
        
    }

    
    public GameObject buildEffect;
    public GameObject sellEffect;
    
  
    private TurretBluePrint turretToBuild;
    private PowersBluePrint powerToCast;

     

    private Node selectedNode;
    public NodeUI nodeUI;
    public RayCastPower raycastpower;
    

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money>=turretToBuild.cost; } }
    void Update()
    {
        
        if(GetComponent<RayCastPower>().enabled)
        {
                     
            
            turretToBuild = null;
            selectedNode = null;
            nodeUI.Hide();
        }
        
        
    }
    public void BuildTurretOn(Node node)
    {
       
    }
    public void SelectNode(Node node)
    {
        
        if(selectedNode==node)
        {
            DeselectNode();
            return;
        }
        
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
        
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
         
    }
   
    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeselectNode();

        


    }
    public void SelectPowerToCast(PowersBluePrint power)
    {
        powerToCast = power;
    }
    // Start is called before the first frame update
    // Update is called once per frame
    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild; 
    }
    public PowersBluePrint GetPowerToCast()
    {
        return powerToCast;
    }
}
