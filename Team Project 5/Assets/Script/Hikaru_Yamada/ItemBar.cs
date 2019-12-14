using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBar : MonoBehaviour
{
    /// <summary>通常カラー</summary>
    [SerializeField] Color btnColor1;
    /// <summary>クリック時カラー</summary>
    [SerializeField] Color btnColor2;
    ///<summary>ボタン</summary>
    [SerializeField] public GameObject[] buttons;
    ///<summary>ポート</summary>
    [SerializeField] public GameObject[] ports;
    /// <summary>現在使用可能なアイテム一覧</summary> 
    [SerializeField] public  GameObject[] canUseItem ;
    //0 = 日記1

    
    /// <summary>現在選択中かどうかを判定する<summary>
    public int selected = 8;

    //ボタンのコンポーネントを保存する配列
    public Button[] btns;
    bool btnChangeFlag = true;

    void Awake()
    {
        int i = 0;
        while (i < 8)
        {
            btns[i] = buttons[i].GetComponent<Button>();
            btns[i].image.color = btnColor1;
            i++;
        }
        
    }

    private void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClick(int number)
    {
        int i = 0;
        if (btns[number].image.color == btnColor2)
        {
            while (i < 8)
            {
                btns[i].image.color = btnColor1;
                i++;
            }
        }
        else
        {
            while (i < 8)
            {
                btns[i].image.color = btnColor1;
                i++;
            }
            btnChangeFlag = !btnChangeFlag;
            //btns[number].image.color = btnChangeFlag ? btnColor1 : btnColor2;
            btns[number].image.color = btnColor2;
        }
        GameObject selectedPort = GameObject.Find("Port" + number);
        if (selectedPort.transform.GetChild(0))
        {
            GameObject selectedItem = selectedPort.transform.GetChild(0).gameObject;
            if (selectedItem.name == "Diary1")
            {
                canUseItem[0].SetActive(true);
            }
        }
        
    }

}


