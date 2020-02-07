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
    ItemBar script;
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
    public BoxCollider saveBoxCollider;

    [SerializeField] GameObject CookingRoomObject;
    CookingRoomScript cookingRoomScript;
    /// <summary>シンク1の水が溜まっているか</summary>
    public bool sink1water;
    /// <summary>シンク2の水が溜まっているか</summary>
    public bool sink2water;
    /// <summary>ガスコンロがついているかどうか</summary>
    public bool flame;
    /// <summary>冷蔵庫1が開いているかどうか</summary>
    public bool freezer1;
    /// <summary>冷蔵庫2が開いているかどうか</summary>
    public bool freezer2;
    /// <summary>パネル選択中</summary>
    public bool panelSelect;
    /// <summary>選択中のアイテム名</summary>
    public GameObject selectedPanel;

    

    void Start()
    {
        script = itemBar.GetComponent<ItemBar>();
        cameraMovementController = cameraObject.GetComponent< CameraMovementController >();
        
        //opensystem = gamemanajer.GetComponent<opensystem>();
        if (Panel)
        {
            Panel.SetActive(false);
        }
        if (CookingRoomObject)
        {
            cookingRoomScript = CookingRoomObject.GetComponent<CookingRoomScript>();
            sink1water = true;
            sink2water = true;

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
                
                if (hit.collider.tag == "Item" || hit.collider.tag == "Panel")
                {
                    //var itemBar = GameObject.Find("CanvasWorld").transform.Find("ItemBar");
                    var itemObject = hit.collider.gameObject;
                    //var itemScript = itemObject.GetComponent<ThisInfo>();

                    int i = 0;
                    while(script.ports[i].transform.childCount > 0)
                    {
                        i++;
                    }
                   
                    var ParentPort = GameObject.Find("Port" + i);
                    //script.canUseItem[i] = itemObject;
                    var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                    messageText.text = itemObject.name + "を入手した。";
                    messageWindow.SetActive(true);
                    if (itemObject.transform.position == new Vector3 (4.12f,0.761f,-9.346f))
                    {
                        cookingRoomScript.DeviceSink();
                    }
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
                    else if (itemObject.tag == "Panel")
                    {
                        itemObject.transform.localScale = new Vector3(1, 60f, 60f);
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

                }
                if (hit .collider.tag == "noLinkZoom")
                {
                    if (cameraMovementController)
                    {
                        var pointObject = hit.collider.gameObject;
                        var zoomObject = GameObject.Find(hit.collider.gameObject.name + "Point");
                        saveBoxCollider = pointObject.GetComponent<BoxCollider>();
                        saveBoxCollider.enabled = false;
                        var zoomPoint = zoomObject.transform;
                        cameraMovementController.Zoom(zoomPoint);
                    }
                }
                if (hit.collider.tag == "reFirstDoor")
                {
                    Scenechange(firstRoom);
                }

                if (hit.collider.tag == "enterDoor")
                {
                    Scenechange(enterRoom);
                }
                if (hit.collider.name == "Water")
                {
                    if (sink1water)
                    {
                        cookingRoomScript.Sink_1(false);
                        sink1water = false;
                    }
                    else
                    {
                        cookingRoomScript.Sink_1(true);
                        sink1water = true;
                    }
                }
                if (hit.collider.name == "Water2")
                {
                    if (sink2water)
                    {
                        cookingRoomScript.Sink_2(false);
                        sink2water = false;
                    }
                    else
                    {
                        cookingRoomScript.Sink_2(true);
                        sink2water = true;
                    }
                }
                if (hit.collider.name == "DeviceSink")
                {
                    if (panelSelect)
                    {
                        cookingRoomScript.DeviceSink(selectedPanel);
                        UseItem();
                        script.selectedItem.transform.localScale = new Vector3(0.2f,0.05f,0.2f);
                        //script.selectedItem.transform.Rotate(new Vector3());
                        //script.selectedItem.transform.localScale = new Vector3();
                        script.selectedItem = null;
                    }
                    else
                    {
                        var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                        messageText.text = "どうやら水は抜けないようだ";
                        messageWindow.SetActive(true);
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

    public void UseItem()
    {
        script.selectedPort = GameObject.Find("Port" + script.selected);
        script.selectedItem = script.selectedPort.transform.GetChild(0).gameObject;
        script.selectedItem.transform.parent = null;
        //script.selectedItem = null;
    }



}

