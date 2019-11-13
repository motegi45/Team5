using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 説明:アイテムバーにつけるコンポーネント
/// </summary>
public class StartBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("ItemBar").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
