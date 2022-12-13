using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;


public class Necromancer : Enemy
{
    enum NecroState : int
    {
        Idle = 0,
        Chasing = 1,
        Attacking = 2,
        Summoning = 3
    }

    [SerializeField] GameObject orb;
    [SerializeField] GameObject assassin;
    [SerializeField] GameObject ghost;
    [SerializeField] GameObject golem;
    [SerializeField] GameObject archer;
    private Animator animator;
    NecroState necroState = NecroState.Idle;
    float waitTimer = 2f;
    float MaxHp;
    bool summon = true;
    protected override void Start()
    {
        MaxHp = enemyHp;
        animator = GetComponent<Animator>();
        base.Start();
    }

    protected override void Update()
    {
        if (player != null)
        {
            switch (necroState)
            {
                case NecroState.Idle:
                    waitTimer -= Time.deltaTime;
                    if (waitTimer <= 0)
                    {
                        necroState = NecroState.Chasing;
                    }
                    break;

                case NecroState.Chasing:
                    base.Update();
                    float distance = Vector3.Distance(transform.position, player.transform.position);
                    animator.SetBool("IsWalking", true);

                    if (distance < 7f)
                    {
                        necroState = NecroState.Attacking;
                    }

                    float bossHalfHp = MaxHp / 2;
                    if  (enemyHp == bossHalfHp && summon == true)
                    {
                        necroState= NecroState.Summoning;
                        summon = false;
                    }
                   

                    break;

                case NecroState.Attacking:
                    animator.SetBool("IsWalking", false);
                    animator.SetTrigger("Attack");
                    necroState = NecroState.Idle;
                    waitTimer = 2f;
                    break;

                case NecroState.Summoning:
                    animator.SetBool("IsWalking", false);
                    animator.SetTrigger("Summon");
                    necroState = NecroState.Idle;
                    waitTimer = 2f;

                    break;
            }
        }


    }

    void SpawnEnemies(GameObject enemyPrefab, int numberOfEnemies, bool isTracking = true)
    {
        if (player != null)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                Vector3 spawnPosition = UnityEngine.Random.insideUnitCircle.normalized * 8;
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

    public void SummonEnemy()
    {
        SpawnEnemies(archer, 3);
        SpawnEnemies(assassin, 5);
        SpawnEnemies(golem, 5);
        SpawnEnemies(ghost, 2);
    }

    public void Spawnorb()
    {
        double valueX = player.transform.position.x - transform.position.x;
        double valueY = player.transform.position.y - transform.position.y;
        double tan = valueY / valueX;
        double angle = ConvertRadians(Math.Atan2(valueY, valueX));

        Vector3 destination = player.transform.position;
        Vector3 source = transform.position;

        Transform orbtransform = Instantiate(orb, source, Quaternion.Euler(0, 0, (float)angle)).transform;

        Vector3 orbDir = (destination - source).normalized;
        orbtransform.GetComponent<NecroOrb>().SetUp(orbDir);


    }

    public static double ConvertRadians(double radians)
    {
        return Mathf.Rad2Deg * radians;
    }
}
