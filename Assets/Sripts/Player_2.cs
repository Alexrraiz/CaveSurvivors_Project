using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;




public class Player_2 : Player
{
    public override void Start()
    {
        base.Start();
        weapons[2].LevelUp();
    }

    public override void Update()
    {
        base.Update();
    }
    
   
}
