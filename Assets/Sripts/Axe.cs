using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : BaseWeapon
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(1);
        }
        Boss boss = collision.GetComponent<Boss>();
        if (boss != null)
        {
            boss.BossDamage(1);
        }
    }
   
}
