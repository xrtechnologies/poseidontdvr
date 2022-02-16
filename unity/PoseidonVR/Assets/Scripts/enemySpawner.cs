using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemySpawner : MonoBehaviour
{
    [Header("Wave selection: Position in array is wavenumber")]
    [SerializeField] GameObject pathStart;
    [SerializeField] List<GameObject> enemyType;
    [SerializeField] List<int> enemyAmount;
    [SerializeField] List<float> densityDelay;
    [SerializeField] List<Vector3> scale;
    [SerializeField] int startingWave;
    [SerializeField] float delayBetweenWaves;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //agent = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        StartCoroutine(spawnEnemy(startingWave, delayBetweenWaves));
    }

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
}
