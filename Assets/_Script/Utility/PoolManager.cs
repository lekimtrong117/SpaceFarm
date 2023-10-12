using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MySingleton<PoolManager>
{
    // t?o Pool b?ng cách nh?p tay
    public List<TrongPool> pools_Collection;
    // t?o pool b?ng script
    private static Dictionary<string, TrongPool> dic_Pool = new Dictionary<string, TrongPool>();
    public  Dictionary<string, TrongPool> dicPool_
    {
        get{ return dic_Pool; }
    }

    private void Awake()
    { }
    

    void Start()
    {
        
        //foreach (TrongPool e in pools_Collection)
        //{
        //    CreatPool(e);
        //    dic_Pool.Add(e.namePool, e);
            
        //}
        
    }
    public void AddNewPool(TrongPool pool)
    {
        if (!dic_Pool.ContainsKey(pool.namePool))
        {
            CreatPool(pool);
            dic_Pool.Add(pool.namePool, pool);
        }
    }
    private void CreatPool(TrongPool pool)
    {
        for (int i = 0; i< pool.total; i++)
        {
            Transform trans = Instantiate(pool.prefab_, Vector3.zero, Quaternion.identity);
            pool.elements.Add(trans);
            trans.gameObject.SetActive(false);
        }
    } 
    public Transform Spawn(string name_pool)
    {
        return dic_Pool[name_pool].OnSpawned();
        
    }
    public void DeSpawn(string name_pool,Transform trans_)
    {
        dic_Pool[name_pool].OnDeSpawned(trans_);
    }

    public void Reset()
    {
       dic_Pool.Clear();
    }

}
    [Serializable]
    public class TrongPool
    {
        public int total;
        public string namePool;
        public Transform prefab_;
        [NonSerialized]
        public List<Transform> elements = new List<Transform>();
        private int index = -1;
        public TrongPool()
        {

        }
        public TrongPool(int total, string namePool, Transform prefab_)
        {
            this.total = total;
            this.namePool = namePool;
            this.prefab_ = prefab_;
        }
    // tr? v? m?t transform là m?t element trong pool và set nó active, index t? 0 ??n TrongPool.Total và reset v? không khi index=TrongPool.Total
        public Transform OnSpawned()
        {
            index++;
            if (index >= elements.Count)
            {
                index = 0;
            }
            Transform trans = elements[index];
            trans.gameObject.SetActive(true);
            trans.gameObject.SendMessage("OnSpawned", SendMessageOptions.DontRequireReceiver);
        
        return trans;

        }
    // Deactive trans ???c truy?n vào
        public void OnDeSpawned(Transform trans_)
        {
            if (elements.Contains(trans_))
            {
                trans_.gameObject.SendMessage("OnDeSpawned", SendMessageOptions.DontRequireReceiver);
                trans_.gameObject.SetActive(false);
            }
        }
    
    }



