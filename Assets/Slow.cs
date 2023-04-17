using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slow : MonoBehaviour
{
    private float initialSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        while (this == true)
        {
            foreach (Collider collider in collision)
            {
                Slower(collider.transform);

            }
        }
        foreach (Collider collider in collision)
        {
            Calm(collider.transform);

        }

    }
    void Slower(Transform enemy)
    {

        NavMeshAgent c = enemy.GetComponent<NavMeshAgent>();
        if (c != null)
        {
            initialSpeed = c.speed;
            c.speed = 1f;
            Debug.Log("SlowingEnemies");
        }
    }

    void Calm(Transform enemy)
    {

        NavMeshAgent c = enemy.GetComponent<NavMeshAgent>();
        if (c != null)
        {
            c.speed = initialSpeed;

        }
    }
}
