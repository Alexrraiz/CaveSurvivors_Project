//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ObjectPool : MonoBehaviour
//{    
//    [SerializeField] GameObject scythe;
//    [SerializeField] GameObject exporb;
//    [SerializeField] GameObject goldcoin;



//    List<GameObject> pooledObjects = new List<GameObject>();
//    int objectIndex;

//    private void Awake()
//    {
//        for (int i = 0; i < 300; i++)
//        {
//            pooledObjects.Add(Instantiate(scythe));
//            pooledObjects.Add(Instantiate(exporb));
//            pooledObjects.Add(Instantiate(goldcoin));
//        }
//    }

//    public GameObject GetObject()
//    {
//        objectIndex %= pooledObjects.Count;
//        return pooledObjects[objectIndex++];
//    }
//}
