using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private IEnemySpawner enemySpawner;
    public List<Enemy> EnemyList;
    public List<string> DeadEnemyList;
    public event Action DeadEnemyEvent;

    private void OnEnable()
    {
        SetCommonSpawner();
        EnemyList = new List<Enemy>(10);
    }

    private void OnDisable()
    {
        DisableSpawner();
    }

    public void SetCommonSpawner()
    {
        enemySpawner = FindObjectOfType<CommonEnemySpawner>();
        enemySpawner.SpawnEnemyEvent += EnemySpawner_SpawnEnemyEvent;
    }

    private void EnemySpawner_SpawnEnemyEvent(Enemy enemy)
    {
        EnemyList.Add(enemy);
        enemy.DeadEvent += Enemy_DeadEvent;
        //Debug.Log($"Count: {EnemyList.Count}");
    }

    private void Enemy_DeadEvent(Enemy enemy)
    {
        EnemyList.Remove(enemy);
        DeadEnemyList.Add(enemy.gameObject.ToString());
        DeadEnemyEvent?.Invoke();
    }

    public void DisableSpawner()
    {
        enemySpawner.SpawnEnemyEvent -= EnemySpawner_SpawnEnemyEvent;
        enemySpawner = null;
    }
}
