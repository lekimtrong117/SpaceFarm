using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class EnemyConfigRecord
{
    //STT enemyID type damage  speed
    public int STT;
    public int enemyID;
    public string type;
    public int damage;
    public int speed;
}
public class EnemyConfig : MyDataTable<EnemyConfigRecord>
{
    public override ConfigCompare<EnemyConfigRecord> DefineCompare()
    {
       ConfigCompare<EnemyConfigRecord> configCompare = new ConfigCompare<EnemyConfigRecord>("type","damage");
        return configCompare;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
