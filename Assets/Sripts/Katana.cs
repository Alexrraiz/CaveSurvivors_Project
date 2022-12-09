using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : BaseWeapon
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        StartCoroutine(KatanaCoroutine());
    }

    IEnumerator KatanaCoroutine()
    {
        while(true)
        {
            spriteRenderer.enabled = true;
            boxCollider2D.enabled = true;
            yield return new WaitForSeconds(1f);

            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(2f - TitleManager.saveData.WPNcooldown);
        }
    }
    private void OnTriggerEnter2D (Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(1 + (1 *level));
        }
        Boss boss = collision.GetComponent<Boss>();
        if (boss != null)
        {
            boss.BossDamage(1 +(1* level));
        }
    }
}
