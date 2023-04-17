using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QualityCode : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int calidad;
    // Start is called before the first frame update
    void Start()
    {
        calidad = PlayerPrefs.GetInt("QualityNumber", 3);
        dropdown.value = calidad;
        AdjustQuality();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AdjustQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("QualityNumber", dropdown.value);
        calidad=dropdown.value;
    }
}
