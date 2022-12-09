using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject player;
    [SerializeField] GameObject merman;
    [SerializeField] GameObject runner;
    [SerializeField] GameObject zombie;
    [SerializeField] GameObject giant;
    [SerializeField] GameObject Boss_Reaper;
        
    private void Start()
    {
        StartCoroutine(SpawnCoroutineEnemy());
    }

    private void Update()
    {
        int seconds = (int)Time.time;

        timerText.text = seconds.ToString();
        int minutes = seconds / 60;

        if (minutes >= 1)
        {
            seconds -= minutes * 60;
        }
        if (seconds < 10 && minutes < 10)
        {
            timerText.text = "0" + minutes.ToString() + ":" + "0" + seconds.ToString();
        }
        else if (seconds < 10)
        {
            timerText.text = minutes.ToString() + ":" + "0" + seconds.ToString();
        }
        else if (minutes < 10)
        {
            timerText.text = "0" + minutes.ToString() + ":" + seconds.ToString();
        }
    }

    private IEnumerator SpawnCoroutineEnemy()
    {


        while (true)
        {
            SpawnEnemies(merman, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 5);
            SpawnEnemies(zombie, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(runner, 5, false);
            SpawnEnemies(giant, 1);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(zombie, 5);
            SpawnEnemies(runner, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(runner, 5);
            SpawnEnemies(merman, 5);
            SpawnEnemies(giant, 2);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 5);
            SpawnEnemies(runner, 5);
            SpawnEnemies(zombie, 5);     
            SpawnEnemies(giant, 3);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 10);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 10);
            SpawnEnemies(zombie, 7);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(runner, 10, false);
            SpawnEnemies(giant, 2);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(zombie, 10);
            SpawnEnemies(runner, 4);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(runner, 12);
            SpawnEnemies(merman, 7);
            SpawnEnemies(giant, 3);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 7);
            SpawnEnemies(runner, 8);
            SpawnEnemies(zombie, 8);
            SpawnEnemies(giant, 4);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 15);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 15);
            SpawnEnemies(zombie, 15);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(runner, 15, false);
            SpawnEnemies(giant, 3);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(zombie, 10);
            SpawnEnemies(runner, 8);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(runner, 10);
            SpawnEnemies(merman, 10);
            SpawnEnemies(giant, 4);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 10);
            SpawnEnemies(runner, 9);
            SpawnEnemies(zombie, 10);
            SpawnEnemies(giant, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 20);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 12);
            SpawnEnemies(zombie, 12);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(runner, 15, false);
            SpawnEnemies(giant, 4);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(zombie, 10);
            SpawnEnemies(runner, 7);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(runner, 20);
            SpawnEnemies(merman, 10);
            SpawnEnemies(giant, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 12);
            SpawnEnemies(runner, 12);
            SpawnEnemies(zombie, 12);
            SpawnEnemies(giant, 6);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 25);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 15);
            SpawnEnemies(zombie, 15);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(runner, 15, false);
            SpawnEnemies(giant, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(zombie, 20);
            SpawnEnemies(runner, 10);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(runner, 20);
            SpawnEnemies(merman, 15);
            SpawnEnemies(giant, 6);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 20);
            SpawnEnemies(runner, 15);
            SpawnEnemies(zombie, 20);
            SpawnEnemies(giant, 7);
            yield return new WaitForSeconds(10f);
            SpawnBoss(Boss_Reaper, 1);
            yield return new WaitForSeconds(20f);

        }
        
    }

    void SpawnEnemies(GameObject enemyPrefab, int numberOfEnemies, bool isTracking = true)
    {
        if (player != null)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                Vector3 spawnPosition = Random.insideUnitCircle.normalized * 8;
                if (!isTracking)
                {
                    spawnPosition = new Vector3(-10, 0, 0);
                }
                spawnPosition += player.transform.position;
                GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                Enemy enemy = enemyObject.GetComponent<Enemy>();
                enemy.isTrackingPlayer = isTracking;

            }
        }
    }

    void SpawnBoss(GameObject bossPrefab, int numberOfboss, bool isTracking = true)
    {
        if (player != null)
        {
            for (int i = 0; i < numberOfboss; i++)
            {
                Vector3 spawnPosition = Random.insideUnitCircle.normalized * 8;
                if (!isTracking)
                {
                    spawnPosition = new Vector3(-10, 0, 0);
                }
                spawnPosition += player.transform.position;
                GameObject bossObject = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
                Boss boss = bossObject.GetComponent<Boss>();
                boss.isTrackingPlayer = isTracking;

            }
        }
    }




}
    
   

