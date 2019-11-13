using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    /// <summary>通常カラー</summary>
    [SerializeField] Color btnColor1;
    /// <summary>クリック時カラー</summary>
    [SerializeField] Color btnColor2;

    //ボタンをキャッシュする変数
    Button btn;
    bool btnChangeFlag = true;

    void Awake()
    {
        //何度もアクセスするのでこの変数にキャッシュ
        btn = gameObject.GetComponent<Button>();
        btn.image.color = btnColor1;
    }

    void Start()
    {
        btn.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        btnChangeFlag = !btnChangeFlag;
        btn.image.color = btnChangeFlag ? btnColor1 : btnColor2;
    }
}
