using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] Camera camera;
    public List<GameObject> cannons;
    public LayerMask mask;
    public float scrollSpeed = 5f;
    
    private GameObject towerToRender;
    private NavMeshAgent agent;
    private bool placing;
    private RaycastHit rHit;
    private NavMeshHit nHit;
    private Ray ray;


    //todo: add rotateable rendering of tower after pressing tower button before placement 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!placing){
            zoomCamera();
        }

        if(Input.GetButtonDown("Fire1") && !placing){
            towerToRender = Instantiate(tower);
            foreach(Transform child in towerToRender.transform){
                cannons.Add(child.gameObject);
            }

            //deactivate the cannons while placing the tower
            foreach(GameObject cannon in cannons){
                cannon.GetComponent<TowerAI>().enabled = false;
            }
            placing = true;
        }

        if(Input.GetMouseButtonDown(1)){
            //cancel the placement
            placing = false;
            Destroy(towerToRender);
        }

        if(placing){
            positionTower();
            rotateTower();
            if(Input.GetMouseButtonDown(0)){
                foreach(GameObject cannon in cannons){
                    cannon.GetComponent<TowerAI>().enabled = true;
                }
                placing = false;
            }
        }
    }

    void positionTower(){
        ray = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out rHit)){
            Vector3 pos = rHit.point;
            
            if(NavMesh.SamplePosition(pos, out nHit, 5f, NavMesh.AllAreas)){
                towerToRender.transform.position = pos;
            }
        }
    }

    void rotateTower(){
        switch(Input.mouseScrollDelta.y){
            case 1:
                towerToRender.transform.Rotate(0.0f, 5f, 0.0f, Space.Self);
                break;
            case -1:
                towerToRender.transform.Rotate(0.0f, -5f, 0.0f, Space.Self);
                break;
            default:
                break;
        }
    }

    void zoomCamera(){
        switch(Input.mouseScrollDelta.y){
            case 1:
                ray = camera.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out rHit)){
                    Vector3 hitPoint = rHit.point;
                    Vector3 dir = (hitPoint - gameObject.transform.position).normalized;
                    gameObject.transform.position += dir * scrollSpeed;
                }
                break;
            case -1:
                ray = camera.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out rHit)){
                    Vector3 hitPoint = rHit.point;
                    Vector3 dir = (hitPoint - gameObject.transform.position).normalized;
                    gameObject.transform.position -= dir * scrollSpeed;
                }
                break;
            default:
                break;
        }
    }
}
