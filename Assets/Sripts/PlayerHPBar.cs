using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image Foreground;
    void Update()
    {
        if (player != null)
        {

            //track player
            transform.position = player.transform.position + new Vector3(0, -0.75f, 0);

            //make hp bar go down as health goes down
            float hpRatio = (float)player.playerHP / player.MaxplayerHP;
            Foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
        }

    }
}
