using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 説明:
/// クリックで Ray を飛ばして、Ray を Scene ウィンドウに表示するコンポーネント
/// また、入手可能なアイテムに触れたとき、そのアイテムの情報をアイテムバーに格納する
/// さらに、ゲーム内のそのアイテムの情報をtrueにする
/// 常に動作している必要がある
/// </summary>
public class RaycastController : MonoBehaviour
{
    /// <summary>Ray が何にも当たらなかった時、Scene に表示する Ray の長さ</summary>
    [SerializeField] float m_debugRayLength = 100f;
    /// <summary>Ray が何かに当たった時に Scene に表示する Ray の色</summary>
    [SerializeField] Color m_debugRayColorOnHit = Color.red;
    /// <summary>レイヤーマスク</summary>
    [SerializeField] LayerMask layerMask = 8;
    /// <summary>ここに GameObject を設定すると、飛ばした Ray が何かに当たった時にそこに m_marker を移動する</summary>
    //[SerializeField] GameObject m_marker;
    /// <summary>飛ばした Ray が当たった座標に m_marker を移動する際、Ray が当たった座標からどれくらいずらした場所に移動するかを設定する</summary>
    //[SerializeField] Vector3 m_markerOffset = Vector3.up / 2;

    void Start()
    {

    }

    void Update()
    {
        // クリックで Ray を飛ばす
        if (Input.GetButtonDown("Fire1"))
        {
            // カメラの位置 → マウスでクリックした場所に Ray を飛ばすように設定する
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; // out パラメータで Ray の衝突情報を受け取るための変数
            // Ray を飛ばして、コライダーに当たったかどうかを戻り値で受け取る
            bool isHit = Physics.Raycast(ray, out hit, 100 , layerMask); // オーバーライドがたくさんあることに注意すること

            // Ray が当たったかどうかで異なる処理をする
            if (isHit)
            {
                // Ray が当たった時は、当たった座標まで赤い線を引く
                Debug.DrawLine(ray.origin, hit.point, m_debugRayColorOnHit);
                if (hit.collider.tag == "Item")
                {
                    var itemBar = GameObject.Find("CanvasWorld").transform.Find("ItemBar");
                    var script = itemBar.GetComponent<ItemBar>();

                    var itemObject = GameObject.Find(hit.collider.gameObject.name);
                    var itemScript = itemObject.GetComponent<ThisInfo>();

                    int i = 0;
                    while(script.canUseItem[i] != null)
                    {
                        i++;
                    }
                    //if(itemScript.isAttach == false)
                    //{
                        var ParentPort = GameObject.Find("Port" + i);
                        script.canUseItem[i] = itemObject;
                        
                        itemObject.transform.parent = ParentPort.transform;
                        itemObject.transform.position = ParentPort.transform.position;
                    itemObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                    itemObject.transform.localScale = new Vector3(110,110,110);
                    
                        
                    //}
                }
                
                
                // m_marker がアサインされていたら、それを移動する
                /*if (m_marker)
                {
                    m_marker.transform.position = hit.point + m_markerOffset;
                }*/
            }
            else
            {
                // Ray が当たらなかった場合は、Ray の方向に白い線を引く
                Debug.DrawRay(ray.origin, ray.direction * m_debugRayLength);
            }
        }
    }
}

