using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRootChangeScale : MonoBehaviour
{
    public CanvasScaler[] canvasScalers;
    
     float ogrinal_scale;
    // Start is called before the first frame update
    void Awake()
    {
        float scale = (float)Screen.width / (float)Screen.height;
        scale = scale * 0.5f / ogrinal_scale;
        scale = scale >= 0.5f ? 1 : 0;
        foreach(CanvasScaler cv in canvasScalers)
        {
            cv.matchWidthOrHeight = scale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
