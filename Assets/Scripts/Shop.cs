
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standartTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint laserBeamer;
    public TurretBluePrint energyTower;
    public TurretBluePrint supportTower;
    public AudioSource click;
    


    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
        
        
    }


    public void SelectStandartTurret()
    {
        click.Play();
        Debug.Log("Turret 1 Purchased");
        buildManager.SelectTurretToBuild(standartTurret);
        
        
    }

    public void SelectMissileLauncher()
    {
        click.Play();
        Debug.Log("Turret 2 Purchased");
        buildManager.SelectTurretToBuild(missileLauncher);
        
    }
    public void SelectLaserBeamer()
    {
        click.Play();
        Debug.Log("Laser Beamer 2 Purchased");
        buildManager.SelectTurretToBuild(laserBeamer);
        
    }
    public void SelectEnergyTower()
    {
        click.Play();
        Debug.Log("Energy Tower 2 Purchased");
        buildManager.SelectTurretToBuild(energyTower);

    }

    public void SelectSupportTower()
    {
        click.Play();
        Debug.Log("Support Tower 2 Purchased");
        buildManager.SelectTurretToBuild(supportTower);

    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
