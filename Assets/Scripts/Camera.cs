using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;

    public float maxdistance = 10.0f;
    // How much we 
    public float mindistance = 1.0f;
    // Start is called before the first frame update
    public float Radius = 3.0f;
    public float Smooth = 2.0f;
    Vector3 looktarget;
    Quaternion rotationEuler;

    public int x = 45;
    public int y = 0;



    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    Vector3 offset;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!target)
        { return; }
        if (target)
        {

            rotationEuler = Quaternion.Euler(y, x, 0);
            if (!Rhit)
            { offset = rotationEuler * new Vector3(0, 0, -distance) + target.position; }
            if (Rhit)
            { offset = rotationEuler * new Vector3(0, 0, -h) + target.position; }
            transform.rotation = Quaternion.Lerp(transform.localRotation, rotationEuler, Smooth * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.localPosition, offset, Smooth * Time.deltaTime);
            distance = Mathf.Clamp(distance, mindistance, maxdistance);
        }
        if (x > 360)
        { x -= 360; }
        else if (x < 0)
        { x += 360; }
    }

    public void leftRate()
    { x += 45; }
    public void RightRate()
    { x -= 45; }

    bool CheckMargin()
    { return Vector3.Distance(transform.position, target.position) > Radius; }


    private bool Rhit;

    private float h;
    void cameraRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(target.position, transform.TransformDirection(-Vector3.forward), out hit))
        {
            if (hit.collider.tag != "Player")
            {
                h = hit.distance / 2;
                Rhit = true;
            }
        }
        else
        { Rhit = false; }

        if (h > distance && Rhit == true)
        { Rhit = false; }
    }
}
