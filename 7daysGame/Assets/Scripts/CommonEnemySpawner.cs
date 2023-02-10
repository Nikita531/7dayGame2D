using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemySpawner : MonoBehaviour
{
    [SerializeField] float delayBeforeStart;
    [SerializeField] float delayWhileSpawn;
    [SerializeField] List<Enemy> enemiesForSpawn;
    [SerializeField] Vector3 transformForSpawn;
    private Coroutine _spawnCouratine;

    private void OnDisable()
    {
        StopSpawn();
    }

    private void OnEnable()
    {
        StartSpawn();
    }

    private IEnumerator SpawnCouratine()
    {
        yield return new WaitForSeconds(delayBeforeStart);
        while (true)
        {
            EnemySpawn();
            yield return new WaitForSeconds(delayWhileSpawn);
        }
    }

    public void StartSpawn()
    {
        _spawnCouratine = StartCoroutine(SpawnCouratine());
    }

    public void StopSpawn()
    {
        if(_spawnCouratine != null)
        StopCoroutine(_spawnCouratine);
    }

    private void EnemySpawn()
    {
        int rn = Random.Range(0, enemiesForSpawn.Capacity);
        Vector3 vectorToSpawn = new Vector3(transformForSpawn.x,transformForSpawn.y,transformForSpawn.z);
        Instantiate(enemiesForSpawn[rn], vectorToSpawn, Quaternion.identity);
        Debug.Log("Spawn");
    }
}
