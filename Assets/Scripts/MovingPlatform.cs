using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    void OnCollisionStay(Collision c)
    {
        if (c.gameObject.tag == "Player")
        { c.gameObject.transform.SetParent(this.transform); }
    }

    void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "Player")
        { c.gameObject.transform.SetParent(null); }
    }
}
