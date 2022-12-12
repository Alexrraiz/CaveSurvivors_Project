using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] bool isBoss;
    [SerializeField] GameObject largeheal;
    [SerializeField] GameObject SuperC;
    [SerializeField] public GameObject attackbox;


    [SerializeField] float speed = 2;
    public float currentspeed;

    [SerializeField] public GameObject player;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float bossHp = 50f;
    internal float MaxbossHp;

    public bool isTrackingPlayer = true;
    bool isInvincible;
    public AudioClip Deathsound;

    public Animator animator;


    Color Originalcolor;

    enum ReaperState
    {
        Chasing = 0,
        Attacking = 1,
        Death = 2,
        Idle = 3        
    }

    ReaperState reaperstate = ReaperState.Idle;
    float waittimer = 1f;

    private void Start()
    {
        animator = GetComponent<Animator>();
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

        Camera.main.GetComponent<PlayerCamera>().player1 = transform;
        Camera.main.orthographicSize = 4;

        yield return new WaitForSecondsRealtime(5f);

        Camera.main.GetComponent<PlayerCamera>().player1 = player.transform;
        Camera.main.orthographicSize = 5;

        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1;
    }

    IEnumerator BossAttack()
    {
        attackbox.SetActive(true);
        animator.SetTrigger("Attack");
        yield return new WaitForSecondsRealtime(0.5f);
        attackbox.SetActive(false);
    }

    IEnumerator BossDeath()
    {
        animator.SetTrigger("Death");
        yield return new WaitForSecondsRealtime(0.8f);
        attackbox.SetActive(false);
        Destroy(gameObject);
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
                TitleManager.saveData.reaperbosscount++;
                TitleManager.saveData.cleargame1 = true;
            }
            //enemy takes damage
            StartCoroutine(InvincibilityCoroutine());
        }

    }

    void Update()
    {
        if (player != null)
        {
            switch (reaperstate)
            {
                case ReaperState.Chasing:

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

                    float distance = Vector3.Distance(transform.position, player.transform.position);

                    animator.SetBool("IsWalking", true);

                    if (distance < 3f)
                    {
                        reaperstate = ReaperState.Attacking;
                    }      
                    
                    if (bossHp <= 0)
                    {
                        reaperstate = ReaperState.Death;
                    }

                    break;
                case ReaperState.Attacking:

                    animator.SetBool("IsWalking", false);
                    StartCoroutine(BossAttack());
                    reaperstate = ReaperState.Idle;
                    waittimer = 2f;
                    break;
                case ReaperState.Death:

                    animator.SetBool("IsWalking", false);
                    StartCoroutine(BossDeath());
                    reaperstate = ReaperState.Idle;
                    waittimer = 2f;
                    break;
                case ReaperState.Idle:

                    waittimer -= Time.deltaTime;
                    if (waittimer <= 0)
                    {
                        reaperstate = ReaperState.Chasing;
                    }

                    break;               
            }
        }

        float bossHalfHp = MaxbossHp / 2;
        if (bossHp == bossHalfHp)
        {
            speed = currentspeed + 1;
        }

    }
}
