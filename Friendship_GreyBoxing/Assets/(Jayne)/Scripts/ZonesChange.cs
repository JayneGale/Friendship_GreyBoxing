using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonesChange : MonoBehaviour
{
    public int nextWaypoint;
    int currentWaypoint;

    private void OnTriggerEnter(Collider other)
    {
        currentWaypoint = this.nextWaypoint;

        if (other.tag == "Player")
        {
            Debug.Log("Player has collided with " + gameObject.name);
            Debug.Log("This collider's waypoint is " + currentWaypoint);
            DogWayfinder.instance.SetDestination(currentWaypoint);
        }
    }
}
