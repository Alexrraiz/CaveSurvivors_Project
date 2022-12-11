using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;

public class Archer : Enemy
{
    enum ArcherState : int
    {
        Idle = 0,
        Chasing = 1,
        Attacking = 2
    }
    [SerializeField] GameObject arrow;
    private Animator animator;
    ArcherState acrherState = ArcherState.Idle;
    float waitTimer = 2f;
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }

    protected override void Update()
    {
        if (player != null)
        {
            switch (acrherState)
            {
                case ArcherState.Idle:
                    waitTimer -= Time.deltaTime;
                    if (waitTimer <= 0)
                    {
                        acrherState = ArcherState.Chasing;
                    }
                    break;

                case ArcherState.Chasing:
                    base.Update();
                    float distance = Vector3.Distance(transform.position, player.transform.position);
                    animator.SetBool("IsWalking", true);
                    if (distance < 5f)
                    {
                        acrherState = ArcherState.Attacking;
                    }
                    break;

                case ArcherState.Attacking:
                    animator.SetBool("IsWalking", false);
                    animator.SetTrigger("Attack");
                    acrherState = ArcherState.Idle;
                    waitTimer = 1f;


                    break;
            }
        }


    }

    public override void Damage(int damage)
    {
        acrherState = ArcherState.Idle;
        waitTimer = 2f;
        base.Damage(damage);
    }

    public void Spawnarrow()
    {
        double valueX = player.transform.position.x - transform.position.x;
        double valueY = player.transform.position.y - transform.position.y;
        double tan = valueY / valueX;
        double angle = ConvertRadians(Math.Atan2(valueY, valueX));

        Vector3 destination = player.transform.position;
        Vector3 source = transform.position;

        Transform arrowtransform = Instantiate(arrow, source, Quaternion.Euler(0, 0, (float)angle)).transform;

        Vector3 arrowDir = (destination - source).normalized;
        arrowtransform.GetComponent<Arrow>().SetUp(arrowDir);


    }

    public static double ConvertRadians(double radians)
    {
        return Mathf.Rad2Deg * radians;
    }
}
