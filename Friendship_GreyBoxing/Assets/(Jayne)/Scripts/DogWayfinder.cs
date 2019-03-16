using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogWayfinder : MonoBehaviour {

    [SerializeField]
    List<DrawGizmo> dogWayPoints;

    //for debugging purposes, otherwise always start at dogwayPoints(0)
    public int startWayPointIndex;
    int currentWayPointIndex;
    NavMeshAgent navmeshAgent;
    AudioSource dogRunAudio;
    public AudioClip dogRunClip;
    public static DogWayfinder instance = null;

    // Use this for initialization
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
 
        navmeshAgent = gameObject.GetComponent<NavMeshAgent>();
        Debug.Log(" dogWayPoints.Count is " + dogWayPoints.Count);
        dogRunAudio = gameObject.GetComponent<AudioSource>();



        if (navmeshAgent == null)
        {
            Debug.LogError("NavmeshAgent component is not attached to " + gameObject.name);                
        }
        else
        {
            if (dogWayPoints != null || startWayPointIndex<= dogWayPoints.Count)
            {
                currentWayPointIndex = startWayPointIndex;
                SetDestination(currentWayPointIndex);
            }
            else
            {
                Debug.LogError("Either StartWayPoint is outside the List, or there is no Waypoint attached to " + gameObject.name);
            }
        }
	}

    public void SetDestination(int waypointIndex)
    {
  //      Debug.Log(" SetDestination called on waypoint " + waypointIndex);
        //If the List isn't empty
        if (dogWayPoints != null)
        {
            //If the proposed destination is outside the List, make it inside the List
            if (waypointIndex >= dogWayPoints.Count)
            {
                waypointIndex = dogWayPoints.Count - 1;
            }
            Vector3 targetVector = dogWayPoints[waypointIndex].transform.position;
            navmeshAgent.SetDestination(targetVector);
            dogRunAudio.PlayOneShot(dogRunClip);
        }
    }
  }
