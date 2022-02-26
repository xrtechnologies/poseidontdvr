using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] GameObject pathStart;
    [SerializeField] float delayBetweenWaves;

    private List<Wave> Waves {get;set;}

    void Start()
    {
        Waves = SampleWaveDefinition.Wave1;
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        foreach(var wave in Waves)
        {
            yield return new WaitForSeconds(delayBetweenWaves);
            foreach (var wavePart in wave.WaveParts)
            {
                var enemyPrefab = Resources.Load<GameObject>(wavePart.EnemyType);
                
                for (int enemy = 0; enemy < wavePart.Amount; enemy++)
                {

                    GameObject currentEnemy = Instantiate(enemyPrefab);
                    var movementScript = currentEnemy.GetComponent<playerMovement>();
                    movementScript.Speed = wavePart.Speed;
                    currentEnemy.transform.position = pathStart.transform.position;
                    currentEnemy.transform.localScale = wavePart.Scale;
                    yield return new WaitForSeconds(wavePart.DensityDelay);
                }
            }
        }
    }
}
