using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;

public class Giant : Enemy
{
    enum GiantState : int
    {
        Idle = 0,
        Chasing = 1,
        Attacking = 2
    }
    [SerializeField] GameObject knife;
    private Animator animator;
    GiantState giantState = GiantState.Idle;
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
            switch (giantState)
            {
                case GiantState.Idle:
                    waitTimer -= Time.deltaTime;
                    if (waitTimer <= 0)
                    {
                        giantState = GiantState.Chasing;
                    }
                    break;

                case GiantState.Chasing:
                    base.Update();
                    float distance = Vector3.Distance(transform.position, player.transform.position);
                    animator.SetBool("IsWalking", true);
                    if (distance < 5f)
                    {
                        giantState = GiantState.Attacking;
                    }
                    break;

                case GiantState.Attacking:
                    animator.SetBool("IsWalking", false);
                    animator.SetTrigger("Attack");
                    giantState = GiantState.Idle;
                    waitTimer = 2f;


                    break;
            }
        }

        
    }

    public override void Damage(int damage)
    {        
        giantState = GiantState.Idle;  
        waitTimer= 2f;
        base.Damage(damage);
    }

    public void Spawnknife()
    {       
        double valueX = player.transform.position.x - transform.position.x;
        double valueY = player.transform.position.y - transform.position.y;
        double tan = valueY / valueX;
        double angle = ConvertRadians(Math.Atan2(valueY, valueX));

        Vector3 destination = player.transform.position;
        Vector3 source = transform.position;
       
        Transform knifetransform = Instantiate(knife, source, Quaternion.Euler(0,0, (float)angle)).transform;

        Vector3 knifeDir = (destination- source).normalized;
        knifetransform.GetComponent<GiantKnife>().SetUp(knifeDir);
        

    }

    public static double ConvertRadians(double radians)
    {
        return Mathf.Rad2Deg * radians;
    }

}
