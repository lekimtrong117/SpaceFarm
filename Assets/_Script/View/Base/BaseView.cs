using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BaseView : MonoBehaviour
{
    public ViewIndex viewIndex;
   
    protected BaseViewAnimation viewAnimation;
    private void Awake()
    {
        viewAnimation = gameObject.GetComponentInChildren<BaseViewAnimation>();
    }
    // Start is called before the first frame update
    public virtual void Setup(ViewParam viewParam)
    {

    }
    private  void ShowView(ViewCallBack viewCallBack)
    {
        viewAnimation.OnShowViewAnimation(() =>
        {
            viewCallBack.callback?.Invoke();
            OnShowView();
        });
    }
    public virtual void OnShowView()
    {

    }
    private void HideView(ViewCallBack viewCallBack)
    {
        viewAnimation.OnHideViewAnimation(() =>
        {
            OnHideView();
            viewCallBack.callback?.Invoke();
            
        });
    }
    public virtual void OnHideView()
    {

    }
}
