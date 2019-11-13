using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 説明:アイテムバーの開閉を行うためのもの
/// 適当なゲームオブジェクトにつけておく
/// </summary>

public class BarOpen : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            OpenClose();
        }
    }

    public void OpenClose()
    {
        if (!GameObject.Find("ItemBar"))
        {
            GameObject.Find("Canvas").transform.Find("ItemBar").gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("ItemBar").SetActive(false);
        }
    }
}
