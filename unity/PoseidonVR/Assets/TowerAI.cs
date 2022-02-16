using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour
{   
    [SerializeField] string targeting = "first";
    [SerializeField] float shotDelay;
    private int tester = 0;
    public List<GameObject> targets;
    public GameObject currTarget;
    private bool shooting = false;

    void Start()
    {
        
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
    /*
    IEnumerator spawnEnemy(int currentWave, float delay){
        yield return new WaitForSeconds(delay);
        if(enemyAmount[currentWave] > 0){
            GameObject currentEnemy = Instantiate(enemyType[currentWave]);
            currentEnemy.transform.position = pathStart.transform.position;
            currentEnemy.transform.localScale = scale[currentWave];
            StartCoroutine(spawnEnemy(currentWave, densityDelay[currentWave]));
            enemyAmount[currentWave] --;
        } else if (currentWave < enemyType.Count - 1) {
            StartCoroutine(spawnEnemy(currentWave + 1, delayBetweenWaves));
        }
    }
    */

    IEnumerator shoot(string currTargeting, float delay){
        yield return new WaitForSeconds(delay);
        if(targets.Count > 0){
            switch(currTargeting){
                case "first":
                    currTarget = targets[0];
                    break;
            }
            tester ++;
            Debug.Log("shooting" + tester);  
            StartCoroutine(shoot(targeting, delay));
        } else {
            shooting = false;
        }
    }
}
