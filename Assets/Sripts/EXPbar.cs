using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPbar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image foreground;

    private void Update()
    {
        float expRatio = (float)player.currentExp / player.expTolevel;

        foreground.transform.localScale = new Vector3(expRatio, 1, 1);
    }
}
