using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSpawner : BaseWeapon
{
    [SerializeField] GameObject axe;
    [SerializeField] GameObject player;
    void Start()
    {
        StartCoroutine(SpawnAxeCoroutine());
    }
   
    IEnumerator SpawnAxeCoroutine()
    {
        while (true)
        {
            if (level >= 1)
            {
                SpawnAxe(axe);
                yield return new WaitForSeconds(10f - TitleManager.saveData.WPNcooldown);
                DestroyAll();
            }
        }

    }

    void SpawnAxe (GameObject axePrefab)
    {
        Vector3 spawnPosition = Random.insideUnitCircle.normalized * 4;
        spawnPosition += player.transform.position;
        GameObject axeObject = Instantiate(axePrefab, spawnPosition, Quaternion.identity);
        Axe axe = axeObject.GetComponent<Axe>();       
        axe.transform.localScale = Vector3.one * level;
    }

    public void DestroyAll()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Axe"))
        {
            Destroy(g);
        }
    }
}
