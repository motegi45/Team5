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

    /// <summary>現在使用可能なアイテムの配列に使うインデックス</summary>
    //public int canIndex;
    public string selectedButton; 
    /// <summary>選択中のアイテム</summary>
    public GameObject selectedItem;
    /// <summary>現在選択中かどうかを判定する<summary>
    public bool selected;

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
        btnChangeFlag = !btnChangeFlag;
        btns[number].image.color = btnChangeFlag ? btnColor1 : btnColor2;
    }

}


