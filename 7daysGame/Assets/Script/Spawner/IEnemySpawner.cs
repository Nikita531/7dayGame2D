using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemySpawner
{
    public delegate void SpawnEnemy(Enemy enemy);
    public event SpawnEnemy SpawnEnemyEvent;
    
    public void StartSpawn();
    public void StopSpawn();
}
