using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DialogIndex
{
    GunInfoDialog = 0,
    MessageDialog = 1,
    VictoryDialog=2,
    LoseDialog=3,
    PauseDialog=4,
    GunSelectEquipDialog=5
}
public class DialogConfig
{
    public static DialogIndex[] dialogIndices =
    {
        DialogIndex.MessageDialog,
        DialogIndex.PauseDialog

    };
}
public class DialogParam
{

}
