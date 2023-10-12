using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

[RequireComponent(typeof(CanvasGroup))]
public class BaseDialogAnimation : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    private void Awake()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }
    public virtual void OnShowDialogAnimation(Action callback)
    {
        canvasGroup.DOFade(1f, 0.5f).OnComplete(() =>
        {

            callback?.Invoke();
        }).SetUpdate(true);
    }
    public virtual void OnHideDialogAnimation(Action callback)
    {
        canvasGroup.DOFade(0f, 0.5f).OnComplete(() =>
        {

            callback?.Invoke();
        }).SetUpdate(true);
    }
    private void Reset()
    {
        gameObject.name = "BaseDialogAnimation";
    }
}
