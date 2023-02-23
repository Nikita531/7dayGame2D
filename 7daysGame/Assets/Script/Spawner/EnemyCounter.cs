using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    private IEnemySpawner enemySpawner;
    public List<Enemy> EnemyList;
    public List<string> DeadEnemyList;

    public event Action GameWinEvent;

    private void OnEnable()
    {
        SetCommonSpawner();
        
    }

    private void OnDisable()
    {
        DisableSpawner();
    }

    public void SetCommonSpawner()
    {
        enemySpawner = FindObjectOfType<CommonEnemySpawner>();
        enemySpawner.SpawnEnemyEvent += EnemySpawner_SpawnEnemyEvent;
        EnemyList = new List<Enemy>(enemySpawner.InitialCount);
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
        if (DeadEnemyList.Count == enemySpawner.InitialCount)
        {
            GameWinEvent?.Invoke();
            //TODO Create SceneManager
            SceneManager.LoadScene("LevelsMenu");
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.J))
    //    {
    //        foreach (var enemy in EnemyList)
    //        {
    //            enemy.TakeDamage(100);
    //        }
    //        //Debug.Log("Kill them All");
    //    }
    //}

    public void DisableSpawner()
    {
        enemySpawner.SpawnEnemyEvent -= EnemySpawner_SpawnEnemyEvent;
        enemySpawner = null;
    }
}
