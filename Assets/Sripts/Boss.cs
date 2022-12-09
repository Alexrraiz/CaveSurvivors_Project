using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] bool isBoss;
    [SerializeField] GameObject largeheal;
    [SerializeField] GameObject SuperC;

    [SerializeField] float speed = 2;
    public float currentspeed;

    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float bossHp = 50f;
    internal float MaxbossHp;

    public bool isTrackingPlayer = true;
    bool isInvincible;
    public AudioClip Deathsound;


    Color Originalcolor;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Originalcolor = GetComponent<SpriteRenderer>().color;
        MaxbossHp = bossHp;
        if (isBoss)
        {
            StartCoroutine(BossCameraCoroutine());
        }
    }

    IEnumerator BossCameraCoroutine()
    {
        Time.timeScale = 0;

        Camera.main.GetComponent<PlayerCamera>().player = transform;
        Camera.main.orthographicSize = 4;

        yield return new WaitForSecondsRealtime(5f);

        Camera.main.GetComponent<PlayerCamera>().player = player.transform;
        Camera.main.orthographicSize = 5;

        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.ONdamage();           
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Originalcolor;
        isInvincible = false;
    }

    internal void BossDamage(int damage)
    {
        if (!isInvincible)
        {
            bossHp = bossHp - damage;
            if (bossHp <= 0)
            {
                AudioSource.PlayClipAtPoint(Deathsound, transform.position);
                Instantiate(SuperC, transform.position, Quaternion.identity);
                Instantiate(largeheal, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
            //enemy takes damage
            StartCoroutine(InvincibilityCoroutine());
        }

    }

    void Update()
    {
        if (player != null)
        {
            Vector3 destination = player.transform.position;
            Vector3 source = transform.position;
            Vector3 direction = destination - source;
            direction.Normalize();

            if (isTrackingPlayer == false)
            {
                direction = new Vector3(1, 0, 0);
            }

            transform.position += direction * Time.deltaTime * speed;

            transform.localScale = new Vector3(direction.x > 0 ? 1 : -1, 1, 1);
        }

        float bossHalfHp = MaxbossHp / 2;
        if (bossHp == bossHalfHp)
        {
            speed = currentspeed + 1;
        }

    }
}
