using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    public static TextUI Instance;
    public Text pickCount;
    public Text requireCount;

    // Start is called before the first frame update
    void Start()
    {
        if (TextUI.Instance == null)
        {
            TextUI.Instance = this;
        }
        else
        {
            if (TextUI.Instance != this)
            {
                Destroy(TextUI.Instance.gameObject);
                TextUI.Instance = this;
            }
        }
        requireCount.text = GameManager.Instance.clearRequire.ToString();
        pickCount.text = GameManager.Instance.Pickup.ToString();
    }

    public void Pickup()
    { pickCount.text = GameManager.Instance.Pickup.ToString(); }
}
