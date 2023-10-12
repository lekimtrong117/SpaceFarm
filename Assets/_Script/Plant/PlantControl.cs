using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantControl : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Collider _collider;
    private Animator _animator;
    private Transform trans;
    public bool isWatered;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
        trans = transform;
    }

    private void Start()
    {
        Fall();
        isWatered = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="Ship")
        {
            if (isWatered==false)
            {
                isWatered = true;
                LevelManager.Instance.wateredPlant++;
                LevelManager.Instance.CheckWinCondition();
                PendulumComboControl.Instance.AddCount();
            }       
            Fall();
        }
        if (col.gameObject.tag == "Connector")
        {
            if (isWatered == false)
            {
                isWatered = true;
                LevelManager.Instance.wateredPlant++;
                LevelManager.Instance.CheckWinCondition();
                PendulumComboControl.Instance.AddCount();
                Rise();
            }
        }
        if (col.gameObject.tag == "Zombie")
        {
            if (isWatered == true)
            {
                isWatered = false;
                LevelManager.Instance.wateredPlant--;
                Fall();
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag=="Ship" && isWatered)
        {
            Rise();
        }
    }


    private void Rise()
    {
        _animator.Play("Rise");
    }
    private void Fall()
    {
        _animator.Play("Fall");
    }



}
