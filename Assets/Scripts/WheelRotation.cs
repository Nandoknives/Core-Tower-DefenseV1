using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public WheelCollider targetWheel;
    private Vector3 wheelPosition = new Vector3();
    private Quaternion wheelRotation = new Quaternion();


    // Update is called once per frame
    void Update()
    {
        targetWheel.GetWorldPose(out wheelPosition, out wheelRotation);
      
        transform.rotation = wheelRotation;
        
        
        
    }
}
