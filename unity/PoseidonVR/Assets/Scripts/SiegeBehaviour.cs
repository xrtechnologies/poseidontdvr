using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SiegeBehaviour : MonoBehaviour
{
    public float halfAttackDelay = 0.5f; 
    public int maxCartExplosionDamage = 15;
    public int cartExplosionDamage = 0;
    public bool reachedPointBeforeCastle = false;
    private bool sieging = false;
    private ParticleSystem particle;
    private NavMeshAgent agent;
    private GameObject targetCastle;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        targetCastle = GameObject.FindGameObjectWithTag("Castle");
    }

    // Update is called once per frame
    void Update()
    {
        if(reachedPointBeforeCastle){
            // Will probably need to change once an actual naming scheme has been decided upon
            Debug.Log(gameObject.name);
            switch(gameObject.name){
                case "Cart(Clone)":
                    var movement = gameObject.GetComponent<playerMovement>();
                    if(movement.waypoints[movement.waypoints.Count - 1] != targetCastle.transform){
                        movement.waypoints.Add(targetCastle.transform);
                    }
                    //agent.SetDestination(targetCastle.transform.position);
                    cartExplosionDamage = maxCartExplosionDamage;
                    reachedPointBeforeCastle = false;
                    break;
                case "Player(Clone)":
                    StartCoroutine(FireAtCastle());
                    reachedPointBeforeCastle = false;
                    particle = gameObject.GetComponent<ParticleSystem>();
                    particle.Play();
                    sieging = true;
                    break;
                default: 
                    return;
            }

        }
    }

    private IEnumerator FireAtCastle()
    {
        while (sieging){
            yield return new WaitForSeconds(halfAttackDelay);
            
        }
    }
}
