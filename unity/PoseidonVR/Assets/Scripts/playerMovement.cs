using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMovement : MonoBehaviour
{

    private GameObject path;
    public List<Transform> waypoints;
    private int currentWaypoint = 0; 
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        path = GameObject.FindGameObjectWithTag("Path");
        waypoints = new List<Transform>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        for (int i = 0; i < path.transform.childCount; i ++){
            waypoints.Add(path.transform.GetChild(i));
        }

        agent.SetDestination(waypoints[currentWaypoint].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 1f && currentWaypoint < waypoints.Count - 1){
            currentWaypoint ++;
            agent.SetDestination(waypoints[currentWaypoint].transform.position);
        }
    }
}
