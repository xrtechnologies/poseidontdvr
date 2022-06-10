using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackAI : MonoBehaviour
{
    public bool shooting = false;
    public List<GameObject> targets;
    public float attackSpeed;

    // Start is called before the first frame update
    void Update(){
        if(targets.Count > 0){
            if(shooting == false) StartCoroutine(Fire());
            shooting = true;
            foreach(GameObject obj in targets){
                if(obj == null) targets.Remove(obj);
            }
        } else {
            shooting = false;
            StopCoroutine(Fire());
        }
    }

    IEnumerator Fire(){
        while(true){
            if(shooting){
                foreach(GameObject obj in targets){
                    obj.GetComponent<EnemyHP>().takeDamage();
                }
            }
            Debug.Log("fuck");
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        targets.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other.gameObject);        
    }
}
