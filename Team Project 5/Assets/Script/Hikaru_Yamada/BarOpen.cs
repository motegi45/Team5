using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 説明:アイテムバーの開閉を行うためのもの
/// 適当なゲームオブジェクトにつけておく
/// </summary>

public class BarOpen : MonoBehaviour
{
    [SerializeField] GameObject itemBar;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject cameraWark;

    public bool flag = false;
    void Start()
    {
       
        itemBar.SetActive(false);
        panel.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(true);

    }
    void Update()
    {
        if (Input.GetKeyDown("1") || Input.GetMouseButtonDown(1))
        {
            OpenClose();
        }
    }

    public void OpenClose()
    {
        if (!flag)
        {
            var cameraScript = cameraWark.GetComponent<CameraWark>();
            //GameObject.Find("Canvas").transform.Find("ItemBar").gameObject.SetActive(true);
            button2.SetActive(false);
            panel.SetActive(true);
            itemBar.SetActive(true);
            if (!cameraScript.flagDown)
            {
                button1.SetActive(true);
            }
            flag = true;
        }
        else
        {
            var cameraScript = cameraWark.GetComponent<CameraWark>();
            //GameObject.Find("ItemBar").SetActive(false);
            button1.SetActive(false);
            panel.SetActive(false);
            itemBar.SetActive(false);
            if (!cameraScript.flagDown)
            {
                button2.SetActive(true);
            }
            flag = false;

        }
    }
}
