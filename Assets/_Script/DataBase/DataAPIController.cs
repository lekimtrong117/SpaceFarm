using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataAPIController : MySingleton<DataAPIController>

{
    [NonSerialized]public bool dataInitDone = false;
    [SerializeField] public DataLocalModel dataModel;
   
    private void Awake()
    {
        dataInitDone = false;
        InitData(() => { dataInitDone = true;
        });
    }
    public void InitData(Action callback)
    {
        dataModel.CreateData(callback);
    }
  public float ReadHighestScore()
    {
        return dataModel.Read<float>(DataPath.HIGHESTSCORE);
    }    
    public void UpdateHighrestScore(float score)
    {
        dataModel.UpdateData(DataPath.HIGHESTSCORE, score, () =>{ });
    }
}
