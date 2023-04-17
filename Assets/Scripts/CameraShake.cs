using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Cinemachine.CinemachineImpulseSource impulseSrc;

    // Start is called before the first frame update
    private  void Awake()
    {
        impulseSrc = GetComponent<Cinemachine.CinemachineImpulseSource>();

    }

    private void OnEnable()
    {
        StartCoroutine(EarthShake());
    }
    // Update is called once per frame
    IEnumerator EarthShake()
    {
        yield return new WaitForSeconds(2.5f);
        impulseSrc.GenerateImpulse();
        
    }
    
   
}
