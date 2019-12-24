using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupControl : MonoBehaviour
{
    public Vector3 rotation = new Vector3(15, 30, 45);

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate( rotation * Time.deltaTime);
    }
}
