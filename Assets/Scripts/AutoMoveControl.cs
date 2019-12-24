using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveControl : MonoBehaviour
{
    public Transform targetMove;
    private Vector3 originVec;
    private Vector3 target;
    public bool isOrigin = true;
    public bool InContrast = false;
    public float moveDamp = 0.2f;
    public float timeToChange = 2f;
    private float t;

    private Vector3 moveVelocity;

    // Use this for initialization
    void Start()
    {
        originVec = transform.position;
    }
    void FixedUpdate()
    {
        if (!InContrast)
        {
            if (!isOrigin)
                target = targetMove.position;
            else
                target = originVec;
        }
        else
        {
            if (isOrigin)
                target = targetMove.position;
            else
                target = originVec;
        }
        //transform.position = Vector3.Lerp(transform.position,target,0.1f);//journeyLength 0-1
        transform.position = Vector3.SmoothDamp(transform.position, target, ref moveVelocity, moveDamp);
        t += Time.deltaTime;
        if (t > timeToChange)
        {
            isOrigin = !isOrigin;
            t = 0;
        }
    }
}
