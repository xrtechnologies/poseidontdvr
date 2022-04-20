using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMovement : MonoBehaviour
{

    private GameObject path;
    public List<Transform> waypoints;
    public float Speed = 1.0f;
    public int currentWaypoint = 0; 
    private NavMeshAgent agent;
    private ParticleSystem particle;
    private bool sieging = false;
    // Start is called before the first frame update
    void Start()
    {
        path = GameObject.FindGameObjectWithTag("Path");
        waypoints = new List<Transform>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.speed *= Speed;
        if(gameObject.name == "Player(Clone)"){
            particle = gameObject.GetComponent<ParticleSystem>();
            particle.Stop();
        }
        for (int i = 0; i < path.transform.childCount; i ++){
            waypoints.Add(path.transform.GetChild(i));
        }

        agent.SetDestination(waypoints[currentWaypoint].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 10f && currentWaypoint < waypoints.Count - 1){
            currentWaypoint ++;
            agent.SetDestination(waypoints[currentWaypoint].transform.position);
        }

        if(agent.remainingDistance < 10f && currentWaypoint == waypoints.Count - 1 && sieging == false){
            //reached the target
            Debug.Log("Thing has reached the last checkpoint");
            var behaviour = gameObject.GetComponent<SiegeBehaviour>();
            behaviour.reachedPointBeforeCastle = true;
            sieging = true;
        }
    }
}
