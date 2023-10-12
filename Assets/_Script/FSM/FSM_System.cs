using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_System : MonoBehaviour
{
    #region FSM
    private FSM_State curentState_;
    public FSM_State CurrentState
    {
        get
        {
            return curentState_;
        }
    }
    public FSM_State previous_state;
    [SerializeField] string state_name;
    public void GotoState(FSM_State new_state)
    { if(curentState_!=null)
        {
            previous_state = curentState_;
        }
        curentState_?.Exit();
        curentState_ = new_state;
        new_state.OnEnter();
    }
    public void GotoState(FSM_State new_state, object data)
    {
        curentState_?.Exit();
        curentState_ = new_state;
        new_state.OnEnter(data);
    }
    #endregion
    #region Messagge from Unity
    public virtual void Awake()
    {

    }
    // Start is called before the first frame update
    public virtual void Start()
    {

    }
    public virtual void OnEnable()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {
      
        curentState_?.Update();
    }



    public virtual void FixedUpdate()
    {
        curentState_?.FixedUpdate();
    }

    public virtual void LateUpdate()
    {
        curentState_?.LateUpdate();
    }
    #endregion

}
