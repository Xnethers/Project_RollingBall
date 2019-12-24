using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganMove : MonoBehaviour
{
    private Vector3 target;
    public GameObject thisobject;
    private Vector3 originVec;
    public Transform Sp;
    public bool isOrigin = true;
    public float moveDamp = 0.2f;
    private Vector3 moveVelocity;

    // Use this for initialization
    void Start()
    {
        isOrigin = true;
        originVec = transform.position;
        thisobject.transform.localPosition = Sp.localPosition;
        target = Sp.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isOrigin)
        { target = originVec; }
        thisobject.transform.position = Vector3.SmoothDamp(thisobject.transform.position, target, ref moveVelocity, moveDamp);

    }
    public void StartMove()
    { isOrigin = !isOrigin; }


}
