using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceControl : MonoBehaviour
{
    public float bounceVelocity = 500f;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player"){
            Rigidbody rb=other.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up*bounceVelocity);
        }
    }
}
