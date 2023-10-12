using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PendulumControl : MonoBehaviour
{
   
   [NonSerialized] public Transform trans;
    //drag in
    public Transform ship1_trans;
    public Transform ship2_trans;
    //m_var
    private float current_rotate_angle;
    public Transform current_anchor;
    public const float pendRotateSpeed = 4;
    ResultViewParams resultViewParams = new ResultViewParams();
    private bool isOn;
    public float maxFuel;
    public float fuelDropSpeed;
    [SerializeField]public float currentFuel;
 
    //check ground
    private Collider[] cols;
    public LayerMask groundMask;
    public float range_checkground;
    private Animator anim;
    // 
    private void Awake()
    {
        trans = transform;
        current_rotate_angle = pendRotateSpeed;
        current_anchor = ship1_trans;
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        CheckGround();
        isOn = false;
        currentFuel = maxFuel;
    }


    private void FixedUpdate()
    {
        if (isOn)
        {
            Rotate();
            CheckFuel();
        }
    }
    public void Step()
    {
        MusicManager.Instance.audioSource.PlayOneShot(MusicManager.Instance.step);
        isOn = true;
        current_rotate_angle = -current_rotate_angle;
        if (current_anchor == ship1_trans)
            current_anchor = ship2_trans;
        else current_anchor= ship1_trans;
        CheckGround();
    }    
    public void CheckGround()
    {
        cols = Physics.OverlapSphere(current_anchor.position, range_checkground, groundMask);
        if (cols.Length < 1)
        {
            isOn = false;
            anim.Play("Crash");
        }
        else
        {
            trans.SetParent(cols[0].gameObject.transform);
        }    
    }
    private void Rotate()
    {if (current_anchor==ship1_trans)
        trans.RotateAround(ship1_trans.position, Vector3.up, current_rotate_angle);
    else
           trans.RotateAround(ship2_trans.position, Vector3.up, current_rotate_angle);
       
    }    
    private void CheckFuel()
    {
        currentFuel -= fuelDropSpeed;
        if (currentFuel <=0)
        {
            resultViewParams.result = Result.fuelRunOut;
            ViewManager.Instance.SwitchView(ViewIndex.ResultView,resultViewParams);
        }
    }
    public void OnCrash()
    {
        resultViewParams.result = Result.crash;
        ViewManager.Instance.SwitchView(ViewIndex.ResultView, resultViewParams);
    }

}
