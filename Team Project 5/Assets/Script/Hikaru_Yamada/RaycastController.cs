using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

/// <summary>
/// 説明:
/// クリックで Ray を飛ばして、Ray を Scene ウィンドウに表示するコンポーネント
/// また、入手可能なアイテムに触れたとき、そのアイテムの情報をアイテムバーに格納する
/// さらに、ゲーム内のそのアイテムの情報をtrueにする
/// 常に動作している必要がある
/// </summary>
public class RaycastController : MonoBehaviour
{
    [SerializeField] string enterRoom;
    [SerializeField] string firstRoom;
    /// <summary>Ray が何にも当たらなかった時、Scene に表示する Ray の長さ</summary>
    [SerializeField] float m_debugRayLength = 100f;
    /// <summary>Ray が何かに当たった時に Scene に表示する Ray の色</summary>
    [SerializeField] Color m_debugRayColorOnHit = Color.red;
    /// <summary>レイヤーマスク</summary>
    [SerializeField] LayerMask layerMask = 8;
    /// <summary> 鍵選択中 </summary>
    public bool keySelect = false;
    public bool keySelect2 = false;
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject bigDoor1;
    [SerializeField] GameObject bigDoor2;
    [SerializeField] GameObject itemBar;
    [SerializeField] GameObject messageWindow;
    /// <summary>ここに GameObject を設定すると、飛ばした Ray が何かに当たった時にそこに m_marker を移動する</summary>
    //[SerializeField] GameObject m_marker;
    /// <summary>飛ばした Ray が当たった座標に m_marker を移動する際、Ray が当たった座標からどれくらいずらした場所に移動するかを設定する</summary>
    //[SerializeField] Vector3 m_markerOffset = Vector3.up / 2;
    [SerializeField] Transform[] zoomPoints;
    [SerializeField] GameObject cameraObject;
    [SerializeField] float m_moveTime = 1.0f;
    Transform zoomBefore;
    bool zoomNew = false;
    [SerializeField] GameObject Panel;
    CameraMovementController cameraMovementController;
    //opensystem opensystem;
    bool clear = false;
    [SerializeField] float m_timer;


    [SerializeField] GameObject sink1;
    SinkWater sinkWater1;
    [SerializeField] GameObject sink2;
    SinkWater sinkWater2;
    public BoxCollider saveBoxCollider;

    void Start()
    {
        
        cameraMovementController = cameraObject.GetComponent< CameraMovementController >();
        if (sinkWater1)
        {
            sinkWater1 = sink1.GetComponent<SinkWater>();
        }
        if (sinkWater2)
        {
            sinkWater2 = sink2.GetComponent<SinkWater>();
        }
        //opensystem = gamemanajer.GetComponent<opensystem>();
        if (Panel)
        {
            Panel.SetActive(false);
        }
        
        
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

            // Ray が当たったかどうかで異なる処理をする1
            if (isHit)
            {
                // Ray が当たった時は、当たった座標まで赤い線を引く
                Debug.DrawLine(ray.origin, hit.point, m_debugRayColorOnHit);
                
                if (hit.collider.tag == "Item")
                {
                    var itemBar = GameObject.Find("CanvasWorld").transform.Find("ItemBar");
                    var script = itemBar.GetComponent<ItemBar>();

                    var itemObject = hit.collider.gameObject;
                    var itemScript = itemObject.GetComponent<ThisInfo>();

                    int i = 0;
                    while(script.canUseItem[i] != null)
                    {
                        i++;
                    }
                   
                    var ParentPort = GameObject.Find("Port" + i);
                    script.canUseItem[i] = itemObject;
                    var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                    messageText.text = itemObject.name + "を入手した。";
                    messageWindow.SetActive(true);
                        itemObject.transform.parent = ParentPort.transform;
                        itemObject.transform.position = ParentPort.transform.position;
                    
                    if (itemObject.name == "Key1" || itemObject.name == "Key2")
                    {
                        itemObject.transform.localScale = new Vector3(100, 100, 100);
                        itemObject.transform.Rotate(new Vector3(180,-90,0));
                    }
                    else if (itemObject.name == "HintPlane")
                    {
                        itemObject.transform.localScale = new Vector3(6, 1, 6);
                        itemObject.transform.Rotate(new Vector3(-90, 0, 0));

                    }
                    else
                    {
                        itemObject.transform.localScale = new Vector3(135, 135, 135);
                        itemObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                    }

                }
                if (hit.collider.tag == "Door")
                {
                    if (keySelect)
                    {
                        
                        var door1Anim = Door1.GetComponent<Animation>();
                        var ItemBarScript = itemBar.GetComponent<ItemBar>();
                        ItemBarScript.DeleteItem();
                        door1Anim.Play();
                        Invoke("ButtonSyutugen",3f);
                        
                    }
                }

                if (hit.collider.tag == "BigDoor")
                {
                    if (keySelect2)
                    {
                        var bigDoor1Anim = bigDoor1.GetComponent<Animation>();
                        var bigDoor2Anim = bigDoor2.GetComponent<Animation>();
                        var ItemBarScript = itemBar.GetComponent<ItemBar>();
                        ItemBarScript.DeleteItem();
                        bigDoor1Anim.Play();
                        bigDoor2Anim.Play();
                        Invoke("ButtonSyutugen", 3f);
                        clear = true;
                        m_timer = 0;
                    }
                }

                if (hit.collider.tag == "zoom")
                {
                        if (cameraMovementController)
                        {
                            var zoomObject = hit.collider.gameObject;
                            saveBoxCollider = zoomObject.GetComponent<BoxCollider>();
                            saveBoxCollider.enabled = false;
                            var zoomPoint = zoomObject.transform;
                            cameraMovementController.Zoom(zoomPoint);
                        }
                    // zoomBeforePosition = new Vector3(beforeTransformPosition);*/
                    //zoomBefore = new Transform(cameraObject.transform);

                }

                if (hit.collider.tag == "reFirstDoor")
                {
                    Scenechange(firstRoom);
                }

                if (hit.collider.tag == "enterDoor")
                {
                    Scenechange(enterRoom);
                }

                if (hit.collider.name == "Sink_1")
                {
                    Debug.Log("aa");
                    if (sinkWater1.m_ToWaterOrDrainage == true)
                    {
                        sinkWater1.ToWaterOrDrainage(false);
                    }
                    else if (sinkWater1.m_ToWaterOrDrainage == false)
                    {
                        sinkWater1.ToWaterOrDrainage(true);
                    }
                }

                if (hit.collider.name == "Sink_2")
                {
                    if (sinkWater2.m_ToWaterOrDrainage == true)
                    {
                        sinkWater2.ToWaterOrDrainage(false);
                    }
                    else if (sinkWater2.m_ToWaterOrDrainage == false)
                    {
                        sinkWater2.ToWaterOrDrainage(true);
                    }
                }
            }
            else
            {
                // Ray が当たらなかった場合は、Ray の方向に白い線を引く
                Debug.DrawRay(ray.origin, ray.direction * m_debugRayLength);
            }
        }
        if (clear)
        {
            m_timer += Time.deltaTime;
            if (m_timer >= 5)
            {
                Panel.SetActive(true);
            }
        }

    }

    void ButtonSyutugen()
    {
        GameObject.Find("CanvasWorld").transform.Find("OpenDoorButton").gameObject.SetActive(true);
    }

    public void Scenechange(string name)
    {
        SceneManager.LoadScene(name);
    }





}

