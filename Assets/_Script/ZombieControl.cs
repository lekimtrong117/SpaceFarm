using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControl : MonoBehaviour
{
    public float offset_checkforward;
    public float range;
    public LayerMask groundMask;
    private Transform trans;
    public float speed;
    private Collider[] cols;
    private Quaternion q;
    private const int maxHp = 5;
    private int hp;
    private void Awake()
    {
        trans = transform;
        q=Quaternion.Euler(0,90,0);
    }

    private void Start()
    {
        hp = maxHp;

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="Ship")
        {
            hp--;
            if(hp<=0)
            trans.gameObject.SetActive(false);
        }
    }

    private void Update()
    {

        if (Time.frameCount%20==0)
        {
            cols=Physics.OverlapSphere(trans.position+trans.forward*offset_checkforward,range,groundMask);
            if (cols.Length<=0)
            {
                trans.forward = q * trans.forward;
            }         
        }

    }
    private void FixedUpdate()
    {
        trans.position = trans.position + transform.forward * speed;
    }





}
