using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject crystalPrefab;
    [SerializeField] GameObject smallheal;
    [SerializeField] GameObject largeheal;
    [SerializeField] GameObject SuperC;
    [SerializeField] GameObject GoldCoin;

    [SerializeField] public GameObject merman;

    [SerializeField] float speed = 1f;
    [SerializeField] public GameObject player;    
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] public float enemyHp = 3f;
    [SerializeField] [Range(0f, 1f)] float smallrandom = 1f;
    [SerializeField] [Range(0f, 1f)] float largerandom = 1f;
    [SerializeField] [Range(0f, 1f)] float SuperCrandom = 1f;
    [SerializeField] [Range(0f, 1f)] float GoldCoinrandom = 1f;


    public bool isTrackingPlayer = true;
    bool isInvincible;
    public AudioClip Deathsound;
      

    Color Originalcolor;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        merman = GameObject.FindGameObjectWithTag("Merman");
        Originalcolor = GetComponent<SpriteRenderer>().color;
    }   

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        { 
           

            if (player.ONdamage())
            {
                return;
            }
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

    public virtual void Damage(int damage)
    {
        if (!isInvincible)
        {
            enemyHp = enemyHp - damage;
            if (enemyHp <= 0)
            {
                AudioSource.PlayClipAtPoint(Deathsound, transform.position);
                Instantiate(crystalPrefab, transform.position, Quaternion.identity);
                if (Random.value < smallrandom)
                {
                    Transform t = Instantiate(smallheal).transform;
                    t.position = transform.position;
                }
                if (Random.value < largerandom)
                {
                    Transform t = Instantiate(largeheal).transform;
                    t.position = transform.position;
                }
                if (Random.value < SuperCrandom)
                {
                    Transform t = Instantiate(SuperC).transform;
                    t.position = transform.position;
                }
                if (Random.value < GoldCoinrandom)
                {
                    Transform t = Instantiate(GoldCoin).transform;
                    t.position = transform.position;
                }
                if (gameObject.tag == "Merman")
                {
                    TitleManager.saveData.mermancount++;
                }
                if (gameObject.tag == "zombie")
                {
                    TitleManager.saveData.zombiecount++;
                }
                if (gameObject.tag == "runner")
                {
                    TitleManager.saveData.runnercount++;
                }
                if (gameObject.tag == "giant")
                {
                    TitleManager.saveData.giantcount++;
                }
                if (gameObject.tag == "acher")
                {
                    TitleManager.saveData.archercount++;
                }
                if (gameObject.tag == "ghost")
                {
                    TitleManager.saveData.ghostcount++;
                }
                if (gameObject.tag == "assassin")
                {
                    TitleManager.saveData.assassincount++;
                }
                if (gameObject.tag == "golem")
                {
                    TitleManager.saveData.golemcount++;
                }
                if (gameObject.tag == "necromancer")
                {
                    TitleManager.saveData.necrobosscount++;
                }
                Destroy(gameObject);
            }
            //enemy takes damage
            StartCoroutine(InvincibilityCoroutine());           
        }       
        
    }

    protected virtual void Update()
    {
        if (player != null)
        {
            Vector3 destination = player.transform.position;
            Vector3 source = transform.position;
            Vector3 direction = destination - source;

            if (!isTrackingPlayer)
            {
                direction = new Vector3(1, 0, 0);
            }
            direction.Normalize();

            transform.position += direction * Time.deltaTime * speed;           

            transform.localScale = new Vector3(direction.x > 0 ? -1 : 1, 1, 1);
        }
    }   
}
