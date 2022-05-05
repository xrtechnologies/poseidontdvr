using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHP : MonoBehaviour
{
    [SerializeField] int maxHP = 100;
    [SerializeField] int regenAmount = 2;
    [SerializeField] GameObject deathParticle;
    public bool castleBreached = false;
    private int damageToTake = 0;
    private int currentHP = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        StartCoroutine(Regenerate());
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("ouch");
        Transform parent = col.gameObject.transform.parent;
        damageToTake = parent.GetComponent<SiegeBehaviour>().cartExplosionDamage;
        GameObject particle = Instantiate(deathParticle, parent.position, parent.rotation);
        particle.transform.GetChild(0).transform.localScale = new Vector3(10f, 10f, 10f);
        Destroy(particle, 3f);
        Destroy(parent.gameObject);
        Debug.Log("HP left: " + currentHP);
        TakeDamage(damageToTake);
    }

    void OnParticleCollision(GameObject other)
    {   

    }

    private IEnumerator Regenerate(){
        while(!castleBreached){
            yield return new WaitForSeconds(5);
            if(currentHP <= maxHP - regenAmount){
                currentHP += regenAmount;
            }
        }
    }

    void TakeDamage(int dmg){
        currentHP -= dmg;
    }

    void Update(){
        if(currentHP <= 0){
            castleBreached = true;
            Destroy(gameObject);
        }
    }
}
