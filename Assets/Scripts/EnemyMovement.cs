using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Enemy stats;

    private Transform target;
    private int wpIndex = 0;


    void Start()
    {
        target = Waypoints.waypoints[0];
    }


    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * stats.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (wpIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wpIndex++;
        target = Waypoints.waypoints[wpIndex];
    }
}
