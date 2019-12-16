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
    /// <summary>ゲーム中に登場するアイテム一覧</summary>
    [SerializeField] public GameObject[] allItem;
    //0 = 日記1
    [SerializeField] GameObject raycast;
    
    /// <summary>現在選択中かどうかを判定する<summary>
    public int selected = 8;

    //ボタンのコンポーネントを保存する配列
    public Button[] btns;
    bool btnChangeFlag = true;

    bool diaryOpen = false;

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
            selected = 8;
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
            selected = number;
        }
        GameObject selectedPort = GameObject.Find("Port" + number);
        if (selectedPort.transform.GetChild(0))
        {
            GameObject selectedItem = selectedPort.transform.GetChild(0).gameObject;
            if (selectedItem.name == "Diary1")
            {
                if (diaryOpen)
                {
                    allItem[0].SetActive(false);
                    diaryOpen = false;
                }
                else
                {
                    allItem[0].SetActive(true);
                    diaryOpen = true;
                }
                
            }
            if (selectedItem.name == "Key1")
            {
                var raycastComp = raycast.GetComponent<RaycastController>();
                if (raycastComp.keySelect)
                {
                    raycastComp.keySelect = false;
                }
                else
                {
                    raycastComp.keySelect = true;
                }
                
            }
            
        }
        
    }

    public void DeleteItem()
    {
        GameObject selectedport = GameObject.Find("Port" + selected);
        Destroy(selectedport.transform.GetChild(0).gameObject);
        var raycastComp = raycast.GetComponent<RaycastController>();
        raycastComp.keySelect = false;
    }

}


