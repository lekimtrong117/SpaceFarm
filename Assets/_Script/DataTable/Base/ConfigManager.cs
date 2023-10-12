using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MySingleton<ConfigManager>
{
    public float elemental_effective_ratio = 2;
    
    IEnumerator Start()
    {
       EnemyConfig enemyConfig = Resources.Load("DataTable/EnemyConfig",typeof(ScriptableObject)) as EnemyConfig;
        yield return new WaitUntil(()=>enemyConfig != null);
        EnemyConfigRecord cf_ = enemyConfig.GetRecordByKeySearch("Human",12);
    }

    
}