using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Energy;
    public int startEnergy=100;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;


    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Energy = startEnergy;

        Rounds = 0;
    }
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
