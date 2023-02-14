using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnBar : MonoBehaviour
{
    private Image powerBarImage;
    private CommonEnemySpawner enemySpawner;
    private EnemyCounter enemyCounter;
    private float fillToIncrease;
    [SerializeField] private bool useDeathToCount;

    private void Start()
    {
        powerBarImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        enemySpawner = FindObjectOfType<CommonEnemySpawner>();
        enemyCounter = FindObjectOfType<EnemyCounter>();
        fillToIncrease = (float)1/enemySpawner.Count;
        if (useDeathToCount)
        {
            enemyCounter.DeadEnemyEvent += EnemyCounter_DeadEnemyEvent;
        }
        else
        {
            enemySpawner.SpawnEnemyEvent += EnemySpawner_SpawnEnemyEvent;
        }
    }

    private void EnemyCounter_DeadEnemyEvent()
    {
        powerBarImage.fillAmount += fillToIncrease;
    }

    private void EnemySpawner_SpawnEnemyEvent(Enemy enemy)
    {
        powerBarImage.fillAmount += fillToIncrease;
        //Debug.Log("INCREACE" + " " + fillToIncrease + " " + powerBarImage.fillAmount);
    }

    private void OnDisable()
    {
        enemySpawner.SpawnEnemyEvent -= EnemySpawner_SpawnEnemyEvent;
    }
}
