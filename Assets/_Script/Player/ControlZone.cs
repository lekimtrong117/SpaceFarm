using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlZone : MonoBehaviour, IPointerDownHandler
{
    private PendulumControl pendulumControl;
   
    public void Initial()
    {
        pendulumControl = FindAnyObjectByType<PendulumControl>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(pendulumControl == null)
        {
            pendulumControl = FindAnyObjectByType<PendulumControl>();
        }
        pendulumControl.Step();
        PendulumComboControl.Instance.ResetSpinCount();
    }

    
}
