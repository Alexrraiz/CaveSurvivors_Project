using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathScreenManager : MonoBehaviour
{
    [SerializeField] TMP_Text mermancount;
    [SerializeField] TMP_Text zombiecount;
    [SerializeField] TMP_Text runnercount;
    [SerializeField] TMP_Text giantcount;
    [SerializeField] TMP_Text golemcount;
    [SerializeField] TMP_Text assassincount;
    [SerializeField] TMP_Text archercount;
    [SerializeField] TMP_Text ghostcount;
    [SerializeField] TMP_Text necrobosscount;
    [SerializeField] TMP_Text reaperbosscount;
    [SerializeField] TMP_Text currentgold;
    [SerializeField] TMP_Text currentlvl;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mermancount.text = TitleManager.saveData.mermancount.ToString();
        zombiecount.text = TitleManager.saveData.zombiecount.ToString();
        runnercount.text = TitleManager.saveData.runnercount.ToString();
        giantcount.text = TitleManager.saveData.giantcount.ToString();
        reaperbosscount.text = TitleManager.saveData.reaperbosscount.ToString();
        currentgold.text = TitleManager.saveData.currentCoins.ToString();
        currentlvl.text = TitleManager.saveData.lvlcount.ToString();
        golemcount.text = TitleManager.saveData.golemcount.ToString();
        ghostcount.text = TitleManager.saveData.ghostcount.ToString();
        assassincount.text = TitleManager.saveData.assassincount.ToString();
        archercount.text = TitleManager.saveData.archercount.ToString();
        necrobosscount.text = TitleManager.saveData.necrobosscount.ToString();
    }
}
