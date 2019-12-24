using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int level = 0;
    public int NextScene;
    public int HomeScene;
    public int clearRequire;
    public int Pickup;
    private void OnEnable()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
        }
        else
        {
            if (GameManager.Instance != this)
            {
                Destroy(GameManager.Instance.gameObject);
                GameManager.Instance = this;
            }
        }
        // SoundManager.Instance.PlaySceneEffect();
        //DontDestroyOnLoad(this.gameObject);
    }

    //換場景
    public void ChangeNextScene()
    {
        SceneManager.LoadScene(NextScene);
        level++;
        Debug.Log("ChangeScene");
    }

    public void ChangeHomeScene()
    {
        SceneManager.LoadScene(HomeScene);
        level++;
        Debug.Log("ChangeScene");
    }


    //過關條件
    public bool CheckPickUp()
    {
        if (Pickup == clearRequire)
        { return true; }
        else
        { return false; }
    }

    //過關
    // public void a(int currentLevel){
    //     //跳到編號1的場景
    //     if (level == 0)
    //     {
    //         ChangeScene(1);
    //     }
    //     else if (level == 1) {
    //         CheckPickUp(2);
    //     }
    //     else if (level == 2) {
    //         CheckPickUp(3);
    //     }
    // }
}
