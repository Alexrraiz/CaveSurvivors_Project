using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar_2 : MonoBehaviour
{
    [SerializeField] Player_2 player2;
    [SerializeField] Image Foreground;
    [SerializeField] public GameObject bar;
    void Update()
    {
        if (TitleManager.saveData.player_num != 1)
        {
            bar.SetActive(false);
        }
        else
        {
            bar.SetActive(true);
        }
        if (player2 != null)
        {

            //track player
            transform.position = player2.transform.position + new Vector3(0, -0.75f, 0);

            //make hp bar go down as health goes down
            float hpRatio = (float)player2.playerHP / player2.MaxplayerHP;
            Foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
        }

    }
}
