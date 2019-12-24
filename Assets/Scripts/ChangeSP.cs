using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSP : MonoBehaviour
{
    public Transform ChangeStartP;
    // Start is called before the first frame update
    void Start()
    { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { GameObject.FindGameObjectWithTag("Start").transform.position = ChangeStartP.position; }
    }
}
