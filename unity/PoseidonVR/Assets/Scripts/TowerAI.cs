using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerAI : MonoBehaviour
{   
    [SerializeField] string targeting = "first";
    [SerializeField] float shotDelay;
    
    public List<GameObject> targets;
    public GameObject currTarget;
    private bool shooting = false;
    void Start(){
    }
    void OnTriggerEnter(Collider col){
        if(col.tag == "Enemy"){
            targets.Add(col.gameObject);
        }
    }
    private void OnTriggerExit(Collider col){
        if(col.tag == "Enemy"){
            targets.Remove(col.gameObject);
        }    
    }
    void FixedUpdate(){
        for(int i = targets.Count - 1; i > -1; i--){
            if(targets[i] == null){
                targets.RemoveAt(i);
            }
        }
    }
    void Update(){
        if(targets.Count > 0 && shooting == false){
            shooting = true;
            StartCoroutine(shoot(targeting, shotDelay));
        }
    }
    //todo: make "first" target not only first in the list but also first in the game => consider distance from next NavMesh point and index of NavMesh point
    IEnumerator shoot(string currTargeting, float delay){

        if(targets.Count == 0) yield break;

        while(shooting){
            yield return new WaitForSeconds(delay);
            if(targets.Count > 0){
                if(currTarget == null){
                    currTarget = targets[0];
                }
                Transform barrel = transform.GetChild(0).gameObject.transform;
                targetEnemy(barrel);
            } else {
                shooting = false;
            }
        }
    }
    // todo make cannon target only enemies it can also hit => raycast for collisions in between
    // idea: when out of range choose next one in List (potentially a loop)
    void targetEnemy(Transform bTransform){
        Quaternion temp = bTransform.rotation;
        for(int i = 0; i < targets.Count; i ++){
            Vector3 dir = (targets[i].transform.position - bTransform.position).normalized;
            bTransform.rotation = Quaternion.LookRotation(dir);
            var angle = bTransform.localEulerAngles.y;
            //fix for negative angles
            angle = (angle > 180) ? angle - 360 : angle;
            //checks angle of the barrel and sets currTarget to the first target with angle < 60°
            if(angle > -30 && angle < 30){
                currTarget = targets[i];
                break;
            }
            bTransform.rotation = temp;
        }
    }
    private static float CalculateDistanceToNextWaypoint(playerMovement playerMovement) =>
        Vector3.Distance(playerMovement.waypoints[playerMovement.currentWaypoint].transform.position, playerMovement.transform.position);
}
