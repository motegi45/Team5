using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///説明:入手可能なアイテムにつけるコンポーネント
///</summary>

public class ThisInfo : MonoBehaviour
{
 
    /// <summary>アイテムの状態(すでにアタッチされているか)</summary>
    public bool isAttach = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(isAttach == true)
        {
            Destroy(this.gameObject);
        }*/
        
    }
}
