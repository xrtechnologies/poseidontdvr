using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour
{   
    [SerializeField] string targeting = "first";
    [SerializeField] float shotDelay;
    
    public List<Transform> cannons;
    public List<GameObject> targets;
    public GameObject currTarget;
    
    private int tester = 0;
    private bool shooting = false;

    void Start(){
        foreach(Transform child in transform){
            cannons.Add(child);
        }
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

    void Update()
    {
        if(targets.Count > 0 && shooting == false){
            shooting = true;
            StartCoroutine(shoot(targeting, shotDelay));
        }
    }

    IEnumerator shoot(string currTargeting, float delay){
        while(shooting){
            yield return new WaitForSeconds(delay);
            if(targets.Count > 0){
                switch(currTargeting){
                    case "first":
                        currTarget = targets[0];
                        break;
                }

                foreach(Transform cannon in cannons){
                    var child = cannon.GetChild(0).gameObject.transform;
                    angleCannon(child);
                }  
            } else {
                shooting = false;
            }
        }
        
    }

    void angleCannon(Transform cTransform){
        Vector3 dir = -(targets[0].transform.position - cTransform.position).normalized;
        Quaternion test = cTransform.rotation;
        cTransform.rotation = Quaternion.LookRotation(dir);
        Debug.Log(cTransform.localEulerAngles.y);
        if(cTransform.localEulerAngles.y - 360 < -30 || cTransform.localEulerAngles.y - 360 > 30){
            cTransform.rotation = test;
        }
    }
}
