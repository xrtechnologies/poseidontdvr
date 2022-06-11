using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackAI : MonoBehaviour
{
    public List<GameObject> targets;
    public float attackSpeed;
    private bool canAttack = false;
    public GameObject particleParent;
    private ParticleSystem particle;
    void Start()
    {
        particle = particleParent.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        StartCoroutine(Fire());
    }
    void Update(){
        foreach(GameObject tar in targets){
            if (tar == null){
                targets.Remove(tar);
            }
        }
        if(targets.Count > 0 && canAttack){
            particle.Emit(1);
            foreach(GameObject obj in targets){
                obj.GetComponent<EnemyHP>().takeDamage();
            }
            canAttack = false;
        }
    }

    IEnumerator Fire(){
        while(true){
            canAttack = true;
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
