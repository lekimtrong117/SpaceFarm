using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class BaseViewAnimation : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    private void Awake()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }
    public virtual void OnShowViewAnimation(Action callback)
    {

        callback?.Invoke();
    }
    public virtual void OnHideViewAnimation(Action callback)
    {
        callback?.Invoke();
    }
    private void Reset()
    {
        gameObject.name = "BaseViewAnimation";
    }
}
