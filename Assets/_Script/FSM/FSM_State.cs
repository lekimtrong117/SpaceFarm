using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_State
{
    public bool enable;
    public virtual void OnEnter()
    {
        enable = true;
    }
    public virtual void OnEnter(object data)
    {

    }
    public virtual void Update()
    {

    }
    public virtual void LateUpdate()
    {

    }
    public virtual void FixedUpdate()
    {

    }
    public virtual void Exit()
    {
        enable = false;
    }
}
