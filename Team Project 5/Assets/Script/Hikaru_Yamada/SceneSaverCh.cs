using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSaverCh : MonoBehaviour
{
    //廊下の保持情報
    /// <summary>日記</summary>
    public static bool diary;
    /// <summary>懐中電灯</summary>
    public static bool penLight;
    /// <summary>鍵</summary>
    public static bool key;
    [SerializeField] public GameObject itemBarObject;
    ItemBar itemBar;
    ///<summary>カメラ</summary>
    [SerializeField] public GameObject mainCamera;
    /// <summary>プレイヤーの位置情報</summary>
    public static Transform cameraLastTransform;
    /// <summary>牢屋のドアの開き情報</summary>
    public static bool doa;
    /// <summary>クッキングルームをクリアしたか</summary>
    public static bool cookingCrea;
    public static bool enterCrea;
    //エンターテイメントルームの保持情報
    /// <summary>ヒントプレート1位置情報</summary>
    public static Transform hintplate1;
    /// <summary>ヒントプレート2位置情報</summary>
    public static Transform hintplate2;
    /// <summary>金庫の開き情報</summary>
    public static bool safeOpen;
    //クッキングルームの保持情報




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //シーン以降直前に保存しておく
    void SceneSave()
    {
        cameraLastTransform = mainCamera.transform;
        itemBar = itemBarObject.GetComponent<ItemBar>();
        int i = 0;
        while (i < 8)
        {
            if (itemBar.ports[i].transform.childCount > 0)
            {
                if (itemBar.ports[i].transform.GetChild(0).transform.gameObject.name == "Diary1")
                {
                    diary = true;
                }
                else if (itemBar.ports[i].transform.GetChild(0).transform.gameObject.name == "Flash Light")
                {
                    penLight = true;
                }
            }
        }
        key = true;
    }

    public static Transform GetCP()
    {
        return cameraLastTransform;
    }

    public static bool GetDiary()
    {
        return diary;
    }

    public static bool GetKey()
    {
        return key;
    }

    public static bool GetLight()
    {
        return penLight;
    }
}
