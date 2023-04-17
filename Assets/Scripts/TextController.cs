using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TMP_Text money;
    public TMP_Text energy;
    public TMP_Text lives;
    public TMP_Text enemiesKilled;
    public TMP_Text enemiesLeft;
    public TMP_Text enemiesLeftRT;

 


    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per framexx
    void Update()
    {
        money.text= "$" + PlayerStats.Money.ToString();
        energy.text = "E" + PlayerStats.Energy.ToString();
        lives.text = PlayerStats.Lives.ToString();
        enemiesKilled.text = "Enemies Killed:  " + WinConditions.enemiesKilled.ToString();
        enemiesLeft.text = "Enemies Left:  " + WinConditions.totalEnemies.ToString();
        enemiesLeftRT.text = WinConditions.totalEnemies.ToString();
 

    }
}
