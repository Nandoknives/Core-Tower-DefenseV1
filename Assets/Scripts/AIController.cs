using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public GameObject goal;
    public int points=1;
    NavMeshAgent agent;
    
    
    
  



    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.FindWithTag("End");
        agent = this.GetComponent<NavMeshAgent>();
        
        

        
    }
    
    
    // Update is called once per frame
    void Update()
    {

        agent.SetDestination(goal.transform.position);

        float distance = Vector3.Distance(transform.position, goal.transform.position);


        if(distance <= 3)
        {
            EndPath();
        }

    }

    void EndPath()
    {
        PlayerStats.Lives-=points;
        WinConditions.totalEnemies--;
        Destroy(gameObject);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }


}
