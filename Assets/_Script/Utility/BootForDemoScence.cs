using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootForDemoScence : MonoBehaviour
{
    void Start()
    {

        DataAPIController.Instance.InitData(() =>
        {
            ViewManager.Instance.SwitchView(ViewIndex.InGameView);
        }  
        );
    }
    private void Awake()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(gameObject);

       
    }

}
