using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedlevelUP : BaseWeapon
{
    [SerializeField] Player player;
    public void Update()
    {
        if (level > 0)
        {
            player.speed = player.Currentspeed + (0.5f * level);
        }
    }
}
