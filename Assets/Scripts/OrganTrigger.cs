using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganTrigger : MonoBehaviour
{
    Collider col;
    public OrganMove[] OrganObject;
    public Renderer m;
    public Material redM;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        ani = GetComponent<Animator>();
        //OrganObject = GameObject.FindObjectsOfType<OrganMove>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m.material = redM;
            foreach (var item in OrganObject)
            { item.StartMove(); }
        }
    }
}
