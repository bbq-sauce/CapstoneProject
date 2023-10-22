using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWaypoint : MonoBehaviour
{
    public GameObject[] waypoints;
    public float speed = 10;
    int current = 0;
    float radius = 1f;
    float y;

    void Update()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < radius)
        {
            current++;
            if(current >= waypoints.Length)
            {
                current = 0;
            }
            else if (current < waypoints.Length)
            {
                Vector3 relativePos = waypoints[current].transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(relativePos);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, speed * Time.deltaTime);
    }
}
