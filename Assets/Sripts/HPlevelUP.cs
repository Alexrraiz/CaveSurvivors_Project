using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPlevelUP : BaseWeapon
{
    [SerializeField] Player player;
    public void Update()
    {
        if (level > 0)
        {
            player.MaxplayerHP = player.CurrentMaxPlayerHP + (2*level);
        }
    }
}
