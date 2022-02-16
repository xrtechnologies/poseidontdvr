using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] Camera camera;
    
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("schmep");
            RaycastHit rHit;
            NavMeshHit nHit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit)){
                Vector3 pos = rHit.point;
                GameObject temp = Instantiate(tower);
                temp.transform.position = pos;
            }
        }
    }
}
