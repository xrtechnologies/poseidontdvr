using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHP : MonoBehaviour
{
    [SerializeField] int maxHP = 100;
    [SerializeField] int regenAmount = 2;
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
        damageToTake = col.gameObject.transform.parent.GetComponent<SiegeBehaviour>().cartExplosionDamage;
        Destroy(col.gameObject.transform.parent.gameObject);
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
