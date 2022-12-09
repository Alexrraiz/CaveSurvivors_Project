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
        SceneManager.LoadScene("Game");
    }

    public void OnUpgradeButtonClick()
    {
        SceneManager.LoadScene("Upgrade");
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Title");
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
