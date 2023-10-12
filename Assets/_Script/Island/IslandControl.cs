using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandControl : MonoBehaviour
{
    private Transform trans;
    [SerializeField] public bool canMove;
    [SerializeField] public Vector3 endPointOffset;
    private Vector3 endPoint;
    private Vector3 targetPoint;
    private Vector3 startPoint;
    private float moveDis;
    public float moveSpeed;
    private void Awake()
    {
        trans = transform;
    }

    private void Start()
    {
        startPoint = transform.position;
        endPoint = transform.position + endPointOffset;
        targetPoint = endPoint;
        moveDis = Vector3.Distance(startPoint, endPointOffset);

    }
    private void FixedUpdate()
    {
        if(canMove)
        Move();
    }

    public void Move()
    {
        trans.position= Vector3.MoveTowards(trans.position, targetPoint, moveDis * Time.fixedDeltaTime * moveSpeed);
        if (trans.position == targetPoint)
        {
            if (targetPoint == endPoint)
                targetPoint = startPoint;
            else
            targetPoint = endPoint;
        }
    }

}

