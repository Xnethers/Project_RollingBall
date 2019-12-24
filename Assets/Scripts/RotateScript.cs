using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public Vector3 rotation;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(rotation);
    }
}
