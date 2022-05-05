using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] int maxHP = 1;
    int currentHP = 0;
    
    void Start(){
        currentHP = maxHP;
    }

    //weirdly triggers when a particle spawned from the enemy itself hits a collider
    void OnParticleCollision(GameObject other){
        takeDamage();   
    }

    void takeDamage(){
        currentHP --;
            if(currentHP <= 0){
                Destroy(gameObject);
            }
    }
}
