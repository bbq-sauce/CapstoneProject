using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    EnemyMovementController controller;
    public Waypoint currentWaypoint;
    FieldOfView fov;
    bool canSeePlayer;


    private void Awake()
    {
        controller = GetComponent<EnemyMovementController>();
        fov = GetComponent<FieldOfView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    // Update is called once per frame
    void Update()
    {
        
        if(fov.canSeePlayer)
        {
            controller.SetDestination(fov.detectedPlayerLocation);
        }
        else if(controller.reachedDestination == true && fov.canSeePlayer == false)
        {
            currentWaypoint = currentWaypoint.nextWayPoint;
            controller.SetDestination(currentWaypoint.GetPosition());
        }

    }
}
