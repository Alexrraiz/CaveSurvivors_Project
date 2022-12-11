using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject player;
    [SerializeField] GameObject assassin;
    [SerializeField] GameObject ghost;
    [SerializeField] GameObject golem;
    [SerializeField] GameObject archer;
    [SerializeField] GameObject Boss_Titan;

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
            yield return new WaitForSeconds(1f);
            SpawnEnemies(assassin, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 5);
            SpawnEnemies(golem, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(ghost, 5, false);
            SpawnEnemies(archer, 1);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(golem, 5);
            SpawnEnemies(ghost, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(ghost, 5);
            SpawnEnemies(assassin, 5);
            SpawnEnemies(archer, 2);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 5);
            SpawnEnemies(ghost, 5);
            SpawnEnemies(golem, 5);
            SpawnEnemies(archer, 3);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 10);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 10);
            SpawnEnemies(golem, 7);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(ghost, 10, false);
            SpawnEnemies(archer, 2);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(golem, 10);
            SpawnEnemies(ghost, 4);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(ghost, 12);
            SpawnEnemies(assassin, 7);
            SpawnEnemies(archer, 3);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 7);
            SpawnEnemies(ghost, 8);
            SpawnEnemies(golem, 8);
            SpawnEnemies(archer, 4);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 15);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 15);
            SpawnEnemies(golem, 15);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(ghost, 15, false);
            SpawnEnemies(archer, 3);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(golem, 10);
            SpawnEnemies(ghost, 8);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(ghost, 10);
            SpawnEnemies(assassin, 10);
            SpawnEnemies(archer, 4);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 10);
            SpawnEnemies(ghost, 9);
            SpawnEnemies(golem, 10);
            SpawnEnemies(archer, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 20);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 12);
            SpawnEnemies(golem, 12);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(ghost, 15, false);
            SpawnEnemies(archer, 4);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(golem, 10);
            SpawnEnemies(ghost, 7);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(ghost, 20);
            SpawnEnemies(assassin, 10);
            SpawnEnemies(archer, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 12);
            SpawnEnemies(ghost, 12);
            SpawnEnemies(golem, 12);
            SpawnEnemies(archer, 6);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 25);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 15);
            SpawnEnemies(golem, 15);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(ghost, 15, false);
            SpawnEnemies(archer, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(golem, 20);
            SpawnEnemies(ghost, 10);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(ghost, 20);
            SpawnEnemies(assassin, 15);
            SpawnEnemies(archer, 6);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 20);
            SpawnEnemies(ghost, 15);
            SpawnEnemies(golem, 20);
            SpawnEnemies(archer, 7);
            yield return new WaitForSeconds(10f);
            SpawnBoss(Boss_Titan, 1);
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