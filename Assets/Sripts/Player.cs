using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Player : MonoBehaviour
{   
    [SerializeField] public GameObject weapon;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] public BaseWeapon[] weapons;
    [SerializeField] public GameObject LevelUpMenu;

    public float speed;
    public float Currentspeed;

    public double playerHP;
    public int MaxplayerHP;
    public int CurrentMaxPlayerHP;

    internal int currentExp;
    internal int expTolevel = 5;
    internal int currentlevel;

    internal double smallrecover = 1.25;
    internal double Largerecover = 2.5;

    public AudioClip LevelUpsound;



    Animator animator;
    bool isInvincible;

    public virtual void Start()
    {
        MaxplayerHP = MaxplayerHP + TitleManager.saveData.MaxHPincrease;
        playerHP = MaxplayerHP;
        animator = GetComponent<Animator>();
    }
    internal void AddLargeHP()
    {
        playerHP = playerHP + Largerecover;
        if (playerHP > MaxplayerHP)
        {
            playerHP = MaxplayerHP;
        }
    }
    internal void AddSmallHP()
    {
        playerHP = playerHP + smallrecover;  
        if (playerHP > MaxplayerHP)
        {
            playerHP = MaxplayerHP;
        }
    }
    internal void AddExp()
    {
        currentExp++;
        if (currentExp == expTolevel)
        {
            AudioSource.PlayClipAtPoint(LevelUpsound, transform.position);
            currentExp = 0;
            expTolevel += 5;
            currentlevel++;
            TitleManager.saveData.lvlcount++;
            Time.timeScale = 0;
            LevelUpMenu.SetActive(true);
        }
    }
    public bool ONdamage()
    {
        

        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine());
            isInvincible = true;

            if (--playerHP <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                SceneManager.LoadScene("DeathScreen");

            }
            return true;
        }
        return false;
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
        isInvincible = false;
    }
   
    public virtual void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(inputX, inputY) * speed * Time.deltaTime;

         
        
        if (inputX > 0)
        {
            transform.localScale = new Vector3 (-1, 1, 1);
        }
        if (inputX < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        bool isRunning = (inputX != 0 || inputY != 0 ? true : false);
        if (inputX != 0)
        {
            isRunning = true;
        }
        else if(inputY !=0)
        {
            isRunning = true;
        }
        animator.SetBool("IsRunning", isRunning);
        
       // goldcount.text = TitleManager.saveData.goldCoins.ToString();
    }    
}
