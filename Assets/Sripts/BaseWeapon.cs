using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public int level = 0;
    public void LevelUp()
    {
        if (++level == 1)
        {
            gameObject.SetActive(true);
        }
    }

}
