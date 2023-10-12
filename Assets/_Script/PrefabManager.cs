using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PrefabManager : MySingleton<PrefabManager>
{
    private void Awake()
    {
        CreateScencePrefab();
    }
    public void CreatePreFabPool(string prefabname, string prefabpath, int total)
    {
        GameObject prefab = (GameObject)Resources.Load(prefabpath, typeof(GameObject));
        Transform prefabTransform = prefab.transform;
        TrongPool newPool = new TrongPool { namePool = prefabname, prefab_ = prefabTransform, total = total };
        PoolManager.Instance.AddNewPool(newPool);

    }
    public void CreateScencePrefab()
    {
      
        if (PoolManager.Instance.dicPool_.ContainsKey("Plant1") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("Plant1", "Prefabs/Plant1",1000);
        }
        if (PoolManager.Instance.dicPool_.ContainsKey("Plant2") == false)
        {
            PrefabManager.Instance.CreatePreFabPool("Plant2", "Prefabs/Plant2", 1000);
        }

    }
}
