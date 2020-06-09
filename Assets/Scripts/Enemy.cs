using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private Transform[] waypoints;
    [SerializeField] [Range(0,1f)] private float moveSpeed = 0.5f;

    private Vector3 targetPosition;
    private int waypointIndex = 0;

    void Start() {
        targetPosition = waypoints[waypointIndex].position;
    }

    void Update() {
        MoveToWaypoints();
    }

    private void MoveToWaypoints() {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * 0.5f);

        if (Vector3.Distance(transform.position, targetPosition) < 0.25f) {
            if (waypointIndex >= waypoints.Length - 1) {
                waypointIndex = 0;
            }
            else {
                waypointIndex++;
            }

            targetPosition = waypoints[waypointIndex].position;
        }
    }
}
