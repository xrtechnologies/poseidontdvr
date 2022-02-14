using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinding : MonoBehaviour
{

    void Start(){
        for (int i = 0; i < transform.childCount; i ++){
            var child = transform.GetChild(i);
            var child2 = transform.GetChild(i >= transform.childCount - 1 ? 0 : i + 1);
            
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.GetComponent<SphereCollider>().enabled = false;
            sphere.transform.localScale = new Vector3(10f,10f,10f);
            sphere.transform.position = child.transform.position;
            /*if(i < transform.childCount - 1) {

            } todo draw Line using linerenderer*/
        }
    }
    void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i ++){
            var child = transform.GetChild(i);
            var child2 = transform.GetChild(i >= transform.childCount - 1 ? 0 : i + 1);
            Gizmos.DrawSphere(child.position, 5f);
            if(i < transform.childCount - 1) {
                Gizmos.DrawLine(child.position, child2.position);
            }
        }
    }
}
