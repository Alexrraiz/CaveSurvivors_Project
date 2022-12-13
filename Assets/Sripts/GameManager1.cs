using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject assassin;
    [SerializeField] GameObject ghost;
    [SerializeField] GameObject golem;
    [SerializeField] GameObject archer;
    [SerializeField] GameObject necromancer;

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
            


            SpawnEnemies(golem, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(ghost, 5);
            SpawnEnemies(ghost, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(archer, 3);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(golem, 5);
            SpawnEnemies(ghost, 5);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 10);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 5);
            SpawnEnemies(ghost, 5);
            SpawnEnemies(golem, 5);
            SpawnEnemies(archer, 3);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(necromancer, 1);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(golem, 8);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(archer, 6);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(golem, 8);
            SpawnEnemies(ghost, 8);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 10);
            SpawnEnemies(archer, 3);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 7);
            SpawnEnemies(ghost, 8);
            SpawnEnemies(golem, 8);
            SpawnEnemies(archer, 4);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(necromancer, 2);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(golem, 15);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(archer, 10);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(golem, 10);
            SpawnEnemies(ghost, 10);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(ghost, 5);
            SpawnEnemies(assassin, 10);
            SpawnEnemies(archer, 4);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 10);
            SpawnEnemies(ghost, 10);
            SpawnEnemies(golem, 10);
            SpawnEnemies(archer, 7);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(necromancer, 3);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(golem, 17);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(archer, 13);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(golem, 12);
            SpawnEnemies(ghost, 12);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(ghost, 10);
            SpawnEnemies(assassin, 15);
            SpawnEnemies(archer, 7);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 12);
            SpawnEnemies(ghost, 12);
            SpawnEnemies(golem, 12);
            SpawnEnemies(archer, 10);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(necromancer, 4);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(golem, 20);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(archer, 20);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(ghost, 25);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 25);
            SpawnEnemies(archer, 10);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(assassin, 20);
            SpawnEnemies(ghost, 15);
            SpawnEnemies(golem, 20);
            SpawnEnemies(archer, 15);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(necromancer, 5);
            yield return new WaitForSeconds(20f);

        }

    }

    void SpawnEnemies(GameObject enemyPrefab, int numberOfEnemies, bool isTracking = true)
    {
        if (TitleManager.saveData.player_num == 0)
        {
            if (player1 != null)
            {
                for (int i = 0; i < numberOfEnemies; i++)
                {
                    Vector3 spawnPosition = Random.insideUnitCircle.normalized * 8;
                    if (!isTracking)
                    {
                        spawnPosition = new Vector3(-10, 0, 0);
                    }
                    spawnPosition += player1.transform.position;
                    GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    Enemy enemy = enemyObject.GetComponent<Enemy>();
                    enemy.isTrackingPlayer = isTracking;

                }
            }
        }
        else
        {
            if (player2 != null)
            {
                for (int i = 0; i < numberOfEnemies; i++)
                {
                    Vector3 spawnPosition = Random.insideUnitCircle.normalized * 8;
                    if (!isTracking)
                    {
                        spawnPosition = new Vector3(-10, 0, 0);
                    }
                    spawnPosition += player2.transform.position;
                    GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    Enemy enemy = enemyObject.GetComponent<Enemy>();
                    enemy.isTrackingPlayer = isTracking;

                }
            }
        }
    }

    void SpawnBoss(GameObject bossPrefab, int numberOfboss, bool isTracking = true)
    {
        if (TitleManager.saveData.player_num == 0)
        {

            if (player1 != null)
            {
                for (int i = 0; i < numberOfboss; i++)
                {
                    Vector3 spawnPosition = Random.insideUnitCircle.normalized * 8;
                    if (!isTracking)
                    {
                        spawnPosition = new Vector3(-10, 0, 0);
                    }
                    spawnPosition += player1.transform.position;
                    GameObject bossObject = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
                    Boss boss = bossObject.GetComponent<Boss>();
                    boss.isTrackingPlayer = isTracking;

                }
            }
        }
        else
        {
            if (player2 != null)
            {
                for (int i = 0; i < numberOfboss; i++)
                {
                    Vector3 spawnPosition = Random.insideUnitCircle.normalized * 8;
                    if (!isTracking)
                    {
                        spawnPosition = new Vector3(-10, 0, 0);
                    }
                    spawnPosition += player2.transform.position;
                    GameObject bossObject = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
                    Boss boss = bossObject.GetComponent<Boss>();
                    boss.isTrackingPlayer = isTracking;

                }
            }
        }
    }




}