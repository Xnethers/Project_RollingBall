using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehaviour : MonoBehaviour

{
    public bool isTrackingXAxis; // 是否開啟 X 軸方向的追蹤
    public float xMargin = 1f;   // 角色離攝影機中心多遠以上會開始追蹤
    public float xSmooth = 8f;   // 攝影機追蹤的速度
    public Vector2 minMaxX;      // 攝影機追蹤的範圍最小最大值 (最小值, 最大值)
    public float xPos;           // 攝影機實際的 X 位置

    [System.Serializable]
    public class TestData
    {
        public string name;
        public int number;
        public Color color;
    }

    [HideInInspector]public TestData[] _testData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}




