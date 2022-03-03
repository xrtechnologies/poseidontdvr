using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticleOnCollision : MonoBehaviour
{
    [SerializeField] GameObject particleToSpawn;

    void OnParticleCollision(GameObject other){
        spawnParticle();
    }

    void spawnParticle(){
        GameObject particle = Instantiate(particleToSpawn, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(particle, 3f);
    }
}
