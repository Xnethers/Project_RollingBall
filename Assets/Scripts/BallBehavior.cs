using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public bool isGround;
    public bool isDead = false;
    public bool isFinish = false;
    Vector3 clearP;
    public Vector3 StartP;
    public Vector3 OriginVec;
    //宣告Rigibody的變數
    private Rigidbody rb;
    public float power = 10f;
    public float jumpPower = 200f;
    // public List<GameObject> usePortal=new List<GameObject>();
    public GameObject next;
    public GameObject RelifeButton;
    public GameObject jumpButton;
    public GameObject ClearPanel;
    // Start is called before the first frame update
    void Start()
    {
        //取得Rigibody物件
        rb = GetComponent<Rigidbody>();
        OriginVec = transform.position;
        RelifeButton.SetActive(false);
        jumpButton.SetActive(true);
        StartP = GameObject.FindGameObjectWithTag("Start").transform.position;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDead)
        { }
        //print(Input.acceleration);
        //將三軸加速度作用到Rigibody
        Vector3 tile = new Vector3(Input.acceleration.x, 0, Input.acceleration.y);
        //推動物理元件(加入速度)
        rb.AddForce(tile * power, ForceMode.VelocityChange);
        //rb.AddTorque(tile, ForceMode.Force);

        if (isFinish)
        {
            transform.position = new Vector3(transform.position.x, clearP.y + Mathf.PingPong(Time.time, 0.5f), transform.position.z);
            ClearPanel.SetActive(true);
        }
    }
    //碰撞事件
    private void OnTriggerEnter(Collider other)
    {
        //確認碰撞對象的tag是否為Finish
        if (other.tag == "Finish" && GameManager.Instance.CheckPickUp())
        {
            isFinish = true;
            clearP = other.transform.GetChild(0).position;
            transform.position = clearP;
            rb.isKinematic = true;
            SoundManager.Instance.PlaySceneEffect("Win");
        }
        //確認碰撞對象的tag是否為Pickup
        if (other.tag == "Pickup")
        {
            GameManager.Instance.Pickup++;
            TextUI.Instance.Pickup();
            //隱藏物件hide pick
            other.gameObject.SetActive(false);
            SoundManager.Instance.PlaySceneEffect("PickUp");
        }
        if (other.tag == "Portal")
        {
            PortalControl portal = other.GetComponent<PortalControl>();
            if (!portal.In)
            {
                // RandomPortal(other);
                next = portal.next;
                next.GetComponent<PortalControl>().In = true;
                Invoke("SetPosition", 0.3f);
                portal.In = true;
            }
        }
        if (other.tag == "Dead")
        {
            isDead = true;
            rb.useGravity = false;
            rb.isKinematic = true;
            RelifeButton.SetActive(true);
            jumpButton.SetActive(false);
            SoundManager.Instance.PlaySceneEffect("Lose");
        }
    }
    public void IsGround()
    { isGround = true; }
    public void IsNotGround()
    { isGround = false; }

    public void Jump()
    {
        if (isGround)
        {
            rb.AddForce(Vector3.up * jumpPower);
            SoundManager.Instance.PlaySceneEffect("Jump");
        }
    }
    public void ReLife()
    {
        transform.position = GameObject.FindGameObjectWithTag("Start").transform.position; ;
        isDead = false;
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
        RelifeButton.SetActive(false);
        jumpButton.SetActive(true);
    }
    #region Portal
    //隨機傳送點
    /*public void RandomPortal(Collider other){
        usePortal.Clear();
        GameObject[] portals = GameObject.FindGameObjectsWithTag("Portal");
        foreach (GameObject portal in portals)
        {
            if(portal != other.gameObject)
                usePortal.Add(portal);
        }
        
        int nextValue =(int)Random.Range(0,usePortal.Count);
        usePortal[nextValue].GetComponent<PortalControl>().In=true;
        next=usePortal[nextValue];
        Invoke("SetPosition",0.3f);
    }*/
    public void SetPosition()
    {
        transform.position = next.transform.position;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Portal")
        {
            PortalControl portal = other.GetComponent<PortalControl>();
            portal.In = false;
        }
    }
    #endregion
}
