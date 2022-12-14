using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpObjectPool : MonoBehaviour
{
    [SerializeField] GameObject exporb;



    List<GameObject> pooledObjects = new List<GameObject>();
    int objectIndex;

    private void Awake()
    {
        for (int i = 0; i < 150; i++)
        {
            
            pooledObjects.Add(Instantiate(exporb));
            
        }
    }

    public GameObject GetObject()
    {
        objectIndex %= pooledObjects.Count;
        return pooledObjects[objectIndex++];
    }
}
