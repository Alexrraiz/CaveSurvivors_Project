using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemywave : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] GameObject player;
    [SerializeField] float enemyHp = 2f;
    [SerializeField] SpriteRenderer spriteRenderer;
    bool isInvincible;
    GameObject Enemytype;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine());
            isInvincible = true;
            if (--enemyHp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1f);
        if (Enemytype == GameObject.FindGameObjectWithTag("runner"))
        {
            spriteRenderer.color = Color.white;
        }
        else
        {
            spriteRenderer.color = Color.green;

        }
        isInvincible = false;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 destination = player.transform.position;
            Vector3 source = transform.position;
            Vector3 direction =  - source;
            direction.Normalize();

            transform.position += direction * Time.deltaTime * speed;

            transform.localScale = new Vector3(direction.x > 0 ? -1 : 1, 1, 1);
        }
    }
}
