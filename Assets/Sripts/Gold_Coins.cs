using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {      
            Destroy(gameObject);
            TitleManager.saveData.goldCoins++;
            TitleManager.saveData.currentCoins++;
        }
    }
}
