using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class TitleManager : MonoBehaviour
{
    [SerializeField] TMP_Text goldcount;
    [SerializeField] Player player;
    [SerializeField] public GameObject PlayerSelect;
    [SerializeField] public GameObject GameSelect;
    [SerializeField] public GameObject Game2;


    public static SaveData saveData;

    string SavePath => Path.Combine(Application.persistentDataPath, "save.data");
    public void Awake()
    {
        if (saveData == null)
            Load();
        else
            Save();
    }
    private void Load()
    {
        FileStream file = null;
        try
        {
            file = File.Open(SavePath, FileMode.Open);
            var bf = new BinaryFormatter();
            saveData = bf.Deserialize(file) as SaveData;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            saveData = new SaveData();
        }
        finally
        {
            if (file != null)
                file.Close();
        }
    }
    private void Save()
    {
        FileStream file = null;
        try
        {
            if (!Directory.Exists(Application.persistentDataPath))
                Directory.CreateDirectory(Application.persistentDataPath);
            file = File.Create(SavePath);
            var bf = new BinaryFormatter();
            bf.Serialize(file, saveData);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        finally
        {
            if (file != null)
                file.Close();
        }
    }

   

    public void Update()
    {
        goldcount.text = TitleManager.saveData.goldCoins.ToString();
    }



    public void OnStartButtonClick()
    {
        PlayerSelect.SetActive(true);       
    }

    public void OnReturnButtonClick()
    {
        PlayerSelect.SetActive(false);
    }

    public void OnReturn2ButtonClick()
    {
        GameSelect.SetActive(false);
    }

    public void OnSelectPlayer1()
    {
        TitleManager.saveData.player_num = 0;
        GameSelect.SetActive(true);
        if (TitleManager.saveData.cleargame1 == false)
        {
            Game2.SetActive(false);
        }
        else
        {
            Game2.SetActive(true);
        }
    }

    public void OnSelectPlayer2()
    {
        TitleManager.saveData.player_num = 1;
        GameSelect.SetActive(true);
        if (TitleManager.saveData.cleargame1 == false)
        {
            Game2.SetActive(false);
        }
        else
        {
            Game2.SetActive(true);
        }

    }

    public void OnSelectGame1()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void OnSelectGame2()
    {
        SceneManager.LoadScene("Game_2");
        Time.timeScale = 1;
        TitleManager.saveData.cleargame1= false;
    }

    public void OnUpgradeButtonClick()
    {
        SceneManager.LoadScene("Upgrade");
        Time.timeScale = 0;
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 0;
        TitleManager.saveData.runnercount = 0;
        TitleManager.saveData.mermancount= 0;
        TitleManager.saveData.zombiecount= 0;
        TitleManager.saveData.giantcount= 0;
        TitleManager.saveData.reaperbosscount= 0;
        TitleManager.saveData.currentCoins= 0;
        TitleManager.saveData.lvlcount= 0; 
        TitleManager.saveData.assassincount= 0;
        TitleManager.saveData.ghostcount = 0;
        TitleManager.saveData.golemcount = 0;
        TitleManager.saveData.archercount = 0;
        TitleManager.saveData.necrobosscount = 0;
    }

    public void OnHltIncButtonClick()
    {
        if (TitleManager.saveData.goldCoins >= 10)
        {
            TitleManager.saveData.goldCoins = TitleManager.saveData.goldCoins - 10;
            TitleManager.saveData.MaxHPincrease = TitleManager.saveData.MaxHPincrease + 1;
        }
        else
        {
            Debug.Log("Not Enough Gold");
        }
    }

    public void OnWpnCoolButtonClick()
    {
        if (TitleManager.saveData.goldCoins >= 20)
        {
            TitleManager.saveData.goldCoins = TitleManager.saveData.goldCoins - 20;
            TitleManager.saveData.WPNcooldown = TitleManager.saveData.WPNcooldown + 0.1f;
        }
        else
        {
            Debug.Log("Not Enough Gold");
        }
    }

    public void OnDmgIncButtonClick()
    {
        Debug.Log("Not Available");
    }

    public void OnCritDButtonClick()
    {
        Debug.Log("Not Available");
    }

    public void OnCritCButtonClick()
    {
        Debug.Log("Not Available");
    }

    public void OnAoEButtonClick()
    {
        Debug.Log("Not Available");
    }

    public void OnKatanaButtonClick()
    {
        player.weapons[0].LevelUp();
        player.LevelUpMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnAxeButtonClick()
    {
        player.weapons[2].LevelUp();
        player.LevelUpMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnScytheButtonClick()
    {
        player.weapons[1].LevelUp();
        player.LevelUpMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnSpeedUpButtonClick()
    {
        player.weapons[4].LevelUp();
        player.LevelUpMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnHealthUpButtonClick()
    {
        player.weapons[3].LevelUp();
        player.LevelUpMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
