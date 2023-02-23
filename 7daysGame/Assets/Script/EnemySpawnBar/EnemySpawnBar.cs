using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnBar : MonoBehaviour
{
    private Image powerBarImage;
    private CommonEnemySpawner enemySpawner;
    private float fillToIncrease;

    private void Start()
    {
        powerBarImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        enemySpawner = FindObjectOfType<CommonEnemySpawner>();
        fillToIncrease = (float)1/enemySpawner.InitialCount;
        //Debug.Log(" enemySpawner.Count" + enemySpawner.Count);
        enemySpawner.SpawnEnemyEvent += EnemySpawner_SpawnEnemyEvent;
    }


    private IEnumerator SpawnBarCoroutine()
    {
        yield return null;
        float endScore = powerBarImage.fillAmount + fillToIncrease;
        while (powerBarImage.fillAmount < endScore)
        {
            powerBarImage.fillAmount += fillToIncrease/20;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void EnemySpawner_SpawnEnemyEvent(Enemy enemy)
    {
        
        StartCoroutine(SpawnBarCoroutine());
    }

    private void OnDisable()
    {
        enemySpawner.SpawnEnemyEvent -= EnemySpawner_SpawnEnemyEvent;
    }
}
