using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawWaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] sawWaypoints;
    [SerializeField] private float speed = 2.0f;

    private int currentWaypointIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(sawWaypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= sawWaypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, sawWaypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
