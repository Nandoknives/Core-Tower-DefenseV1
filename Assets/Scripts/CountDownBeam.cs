using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownBeam : MonoBehaviour
{
    public TMP_Text clockTextSat;
    public TMP_Text clockTextHea;
    public TMP_Text clockTextSlo;
    public float cooldownTimeSat = 10f;
    public float cooldownTimeHea = 10f;
    public float cooldownTimeSlo = 10f;
    private float temporalCoolDownSat;
    private float temporalCoolDownHea;
    private float temporalCoolDownSlo;
    public bool fired1;
    public bool fired2;
    public bool fired3;
    // Start is called before the first frame update
    void Start()
    {
        temporalCoolDownSat = cooldownTimeSat;
        temporalCoolDownHea = cooldownTimeHea;
        temporalCoolDownSlo = cooldownTimeSlo;
        clockTextSat.enabled = false;
        clockTextHea.enabled = false;
        clockTextSlo.enabled = false;
        fired1 = false;
        fired2 = false;
        fired3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fired1 == true)
        {
            ConteoSat();
        }
        if (fired2 == true)
        {
            ConteoHea();
        }
        if (fired3 == true)
        {
            ConteoSlo();
        }
    }
    void ConteoHea()
    {
        clockTextHea.enabled = true;
        cooldownTimeHea -= Time.deltaTime;
        cooldownTimeHea = Mathf.Clamp(cooldownTimeHea, 0f, Mathf.Infinity);
        clockTextHea.text = Mathf.Round(cooldownTimeHea).ToString();
        if (cooldownTimeHea == 0f)
        {
            
            
            clockTextHea.enabled = false;
            cooldownTimeHea = temporalCoolDownHea;
            fired2 = false;
        }

    }
    void ConteoSlo()
    {
        clockTextSlo.enabled = true;
        cooldownTimeSlo -= Time.deltaTime;
        cooldownTimeSlo = Mathf.Clamp(cooldownTimeSlo, 0f, Mathf.Infinity);
        clockTextSlo.text = Mathf.Round(cooldownTimeSlo).ToString();
        if (cooldownTimeSlo == 0f)
        {
            
            
            clockTextSlo.enabled = false;
            cooldownTimeSlo = temporalCoolDownSlo;
            fired3 = false;
        }

    }
    void ConteoSat()
    {
        clockTextSat.enabled = true;
        cooldownTimeSat -= Time.deltaTime;
        cooldownTimeSat = Mathf.Clamp(cooldownTimeSat, 0f, Mathf.Infinity);
        clockTextSat.text = Mathf.Round(cooldownTimeSat).ToString();
        if (cooldownTimeSat == 0f)
        {
            
            
            clockTextSat.enabled = false;
            cooldownTimeSat = temporalCoolDownSat;
            fired1 = false;
        }

    }

}
