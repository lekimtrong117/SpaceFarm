using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootLoader : MonoBehaviour
{
    void Start()
    {
        DataAPIController.Instance.InitData(() =>
        {
            LoadSceenManager.Instance.ShowLoadScreenLogo(() =>
            {
               LoadSceenManager.Instance.LoadScence("Buffer", () =>
                {
                   ViewManager.Instance.SwitchView(ViewIndex.HomeView);
                   
               });
            });
        });
    }
    private void Awake()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(this.gameObject);
    }
}