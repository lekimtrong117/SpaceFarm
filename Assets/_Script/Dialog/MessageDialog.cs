using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDialog : BaseDialog
{
    // Start is called before the first frame update
    public override void Setup(DialogParam dialogParam)
    {
       
    }
    public void OnClose()
    {
        DialogManager.Instance.HideAllDialog();
    }
}
