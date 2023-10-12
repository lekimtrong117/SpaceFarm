using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform trans;
    public Vector3 offsetToAnchor;
    private PendulumControl pendulum;
    [SerializeField] public float lerp_speed = 1;
    private void Awake()
    {
        pendulum = FindAnyObjectByType<PendulumControl>();
        trans = transform;
    }
    private void Start()
    {
        offsetToAnchor = trans.position - pendulum.current_anchor.position;
    }

    private void FixedUpdate()
    {
        MoveCamera();
    }
    public void MoveCamera()
    {
        trans.position = Vector3.Lerp(trans.position, pendulum.current_anchor.position + offsetToAnchor, lerp_speed);
    }

}

    



