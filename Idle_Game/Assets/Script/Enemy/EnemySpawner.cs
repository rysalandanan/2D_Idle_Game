using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyObject;
    [SerializeField] private float spawnDelay;
    private int ranInd = 0;
   public void SpawnEnemy()
   {
        ranInd = Random.Range(0, enemyObject.Length);
        StartCoroutine(SpawnEnemyDelay());
   }
    private IEnumerator SpawnEnemyDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        enemyObject[ranInd].gameObject.SetActive(true);
    }
}
