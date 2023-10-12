using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDialog : MonoBehaviour
{
    public DialogIndex dialogIndex;

    private BaseDialogAnimation dialogAnimation;
    private void Awake()
    {
        dialogAnimation = gameObject.GetComponentInChildren<BaseDialogAnimation>();
    }
    // Start is called before the first frame update
    public virtual void Setup(DialogParam dialogParam)
    {

    }
    private void ShowDialog(DialogCallBack dialogCallBack)
    {
        dialogAnimation.OnShowDialogAnimation(() =>
        {
            dialogCallBack.callback?.Invoke();
            OnShowDialog();
        });
    }
    public virtual void OnShowDialog()
    {

    }
    private void HideDialog(DialogCallBack dialogCallBack)
    {
        dialogAnimation.OnHideDialogAnimation(() =>
        {
            dialogCallBack.callback?.Invoke();
            OnHideDialog();
        });
    }
    public virtual void OnHideDialog()
    {

    }
}
