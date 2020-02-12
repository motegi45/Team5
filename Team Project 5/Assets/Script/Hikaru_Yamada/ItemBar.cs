using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBar : MonoBehaviour
{
    /// <summary>通常カラー</summary>
    [SerializeField] public Color btnColor1;
    /// <summary>クリック時カラー</summary>
    [SerializeField] public Color btnColor2;
    ///<summary>ボタン</summary>
    [SerializeField] public GameObject[] buttons;
    ///<summary>ポート</summary>
    [SerializeField] public GameObject[] ports;
    /// <summary>現在使用可能なアイテム一覧</summary> 
    //[SerializeField] public  GameObject[] canUseItem ;
    /// <summary>ゲーム中に登場するアイテム一覧</summary>
    [SerializeField] public GameObject[] allItem;
    //0 = 日記1
    [SerializeField] GameObject raycast;
    [SerializeField] Transform hint;
    public GameObject[] allItemListPort = new GameObject[8];
    public GameObject[] allItemList = new GameObject[8];
    /// <summary>直前に選択されていたポート</summary>
    //public GameObject selectedBefore;
    /// <summary>現在選択中のポート</summary>
    public GameObject selectedPort;
    ///<summary>現在選択中のアイテム</summary>
    public GameObject selectedItem;
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
        //var hintsystem = hint.GetComponent<hintsystem>();
    }

    void Update()
    {
        
    }

    public void OnClick(int number)
    {
        var raycastComp = raycast.GetComponent<RaycastController>();
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
        selectedPort = GameObject.Find("Port" + number);
        if (0 < selectedPort.transform.childCount)
        {
            selectedItem = selectedPort.transform.GetChild(0).gameObject;
            Debug.Log(selectedItem.name);
            if (selectedItem.name == "犠牲者の手記")
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
            if (selectedItem.name == "金庫取り扱い説明書")
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
            if (selectedItem.name == "謎のメモ")
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
            if (selectedItem.name == "牢屋のカギ")
            {
                if (raycastComp.keySelect)
                {
                    raycastComp.keySelect = false;
                }
                else
                {
                    raycastComp.keySelect = true;
                }
                
            }
            if (selectedItem.name == "Key2")
            {
                if (raycastComp.keySelect)
                {
                    raycastComp.keySelect2 = false;
                }
                else
                {
                    raycastComp.keySelect2 = true;
                }
            }
            if (selectedItem.tag == "Panel")
            {
                
                if (selected == 8)
                {
                }
                else
                {
                    raycastComp.selectedPanel = selectedItem;
                }
            }
            if (selectedItem.name == "KeyPlateHole")
            {
                
            }
            if (selectedItem.name == "IceChangesFrom")
            {
            
            }
        }
        if (selected == 8)
        {
            selectedItem = null;
            selectedPort = null;
        }
        
    }

    public void DeleteItem()
    {
        selectedPort = GameObject.Find("Port" + selected);
        Destroy(selectedPort.transform.GetChild(0).gameObject);
        var raycastComp = raycast.GetComponent<RaycastController>();
        raycastComp.keySelect = false;
    }

    public void UseItem()
    {
        selectedPort = GameObject.Find("Port" + selected);
        selectedItem = selectedPort.transform.GetChild(0).gameObject;
        selectedItem.transform.parent = null;
    }
    public void ItemList()
    {
        int i = 0;
        while (i < 8)
        {
          
            allItemListPort[i] = GameObject.Find("Port" + i);
            if (0 < allItemListPort[i].transform.childCount)
            {
                var allItem = allItemListPort[i].transform.GetChild(0).gameObject;
                allItemList[i] = allItem;
            }
            i++;

        }
       
    }

}


