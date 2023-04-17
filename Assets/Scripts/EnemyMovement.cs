using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    public float rotSpeed = 2f;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];

    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        Vector3 lookAtGoal = new Vector3(dir.x, this.transform.position.y, dir.z);
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(dir), Time.deltaTime * rotSpeed);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;
    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
