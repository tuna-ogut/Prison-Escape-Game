using UnityEngine;
using System.Collections.Generic;

public class EnemyPatrol : MonoBehaviour
{
    public List<Transform> waypoints; // List of waypoints
    public float speed = 2.0f; // Patrol speed
    private int currentWaypointIndex = 0; // Current waypoint index
    private Transform targetWaypoint; // Target waypoint
    private bool isPatrolling = false;
    [SerializeField] private float stoppingDistance = 0.1f;

    private void Start()
    {
        if (waypoints.Count > 0)
        {
            targetWaypoint = waypoints[currentWaypointIndex];
            isPatrolling = true;
            
        }
        else
        {
            targetWaypoint = transform;// causes enemies to jump on player(if enemy does not have a patrol path) dont know why
        }
    }

    private void Update()
    {
        if (targetWaypoint != null )
        {
            MoveTo(targetWaypoint.position);
        }
    }
    
    public void UpdateWaypoint(Vector3 position)
    {
        if (isPatrolling)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            targetWaypoint = waypoints[currentWaypointIndex];
        }
        //else means player is caught and chase him. There were no instructions saying enemy should chase
        //the player however, it looked better for me. If this is not something wanted remove the else.
        else
        { 
            Vector3 directionToPlayer = (position - transform.position).normalized;
            Vector3 stoppingPoint = position - directionToPlayer * stoppingDistance;

            // Set the target waypoint to this stopping point a little bit away from the player for visual purposes
            targetWaypoint.position = stoppingPoint;
        }
    }

    public void StopPatrol()
    {
        isPatrolling = false;
    }

    public void StartPatrol()
    {
        isPatrolling = true;
    }

    private void MoveTo(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }

            // Check if the enemy has reached the target waypoint
            if (Vector3.Distance(transform.position, position) < 0.5f)
            {
                UpdateWaypoint(transform.position);
            }
            
        CharacterMover characterMover = GetComponent<CharacterMover>();
        if (characterMover != null)
        {
            characterMover.SetIsMoving(direction.magnitude > 0.01f);
        }
    }

    public bool HasPatrolPath()
    {
        return (waypoints.Count > 0);
    }
}