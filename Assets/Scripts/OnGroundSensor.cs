using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundSensor : MonoBehaviour
{

    public SphereCollider sphereCol;
    public float offset = 0.25f;//<0.25
    public float radiusOffset = 0.3f;
    private float radius;
    bool m_Started;
    [SerializeField]private Collider[] outputCols;

    // Use this for initialization
    void Awake()
    {
        sphereCol = GetComponentInParent<SphereCollider>();
        // radius = sphereCol.radius + 0.05f;//- 0.05
        m_Started=true;
        radius = sphereCol.radius - radiusOffset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        //offest=0.05f
        // Collider[] outputCols = Physics.OverlapSphere(transform.position - transform.up * offset, radius, LayerMask.GetMask("Ground"));
        
        outputCols = Physics.OverlapBox(transform.position-Vector3.up*offset,new Vector3(radius,radius/4,radius),Quaternion.identity,LayerMask.GetMask("Ground"));
        if (outputCols.Length != 0)
        { SendMessageUpwards("IsGround"); }
        else
        { SendMessageUpwards("IsNotGround"); }
        // if (GetGroundDistance() < sphereCol.radius - offset)
        //     SendMessageUpwards("IsGround");
        // else
        //     SendMessageUpwards("IsNotGround");
    }
    /*public float GetGroundDistance()
    {//取得玩家與下方地面的距離
        Vector3 targetPoint;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down * 0.1f, out hit,100, 1 << LayerMask.NameToLayer("Ground")))
        {
            targetPoint = hit.point;
            Debug.DrawRay(transform.position, Vector3.down * 100, Color.green);
            return Vector3.Distance(transform.position, targetPoint);
        }
        else
        {
            return 100;
        }
    }*/
    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
         //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            Gizmos.DrawWireCube(transform.position-Vector3.up*offset,new Vector3(radius,radius/4,radius));
    }
}
