using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectTilter : MonoBehaviour
{
    private NavMeshAgent agent;
    private Quaternion lookRotation;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        lookRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance<2.0f) return;
        var isHit = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit);
        var normal = hit.normal;


        if(isHit)
        {
            Vector3 direction = agent.velocity;
            direction.y = 0.0f;
            if(direction.magnitude > 0.1f || normal.magnitude > 0.1f) 
            {
                var qLook = Quaternion.LookRotation(direction, Vector3.up);
                var qNorm = Quaternion.FromToRotation(Vector3.up, normal);
                lookRotation = qNorm * qLook;
            }
            // soften the orientation
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime/0.1f);
        }
    }

}