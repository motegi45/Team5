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
    [SerializeField] string cookRoom;
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

    [SerializeField] GameObject flameEffect;
    Flame flameScript;
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
    public GameObject IceKeyPlateClone;
    public GameObject IceKeyObjectClone;
    public bool waterIn;
    /// <summary>選択中のアイテム名</summary>
    public GameObject selectedPanel;
    [SerializeField] GameObject deviceSinkObject;
    DeviceSink deviceSink;
    [SerializeField] GameObject stone1;
    [SerializeField] GameObject stone2;
    /// <summary>石板を入手したか</summary>
    public bool stone;

    [SerializeField] GameObject hintObject;
    hintsystem hintsystem;
    bool left = false;
    bool right = false;
    SceneSaverCh sceneSaverCh;
    /// <summary>石板のトランスフォーム</summary>
    [SerializeField] GameObject stoneTransform1;
    [SerializeField] GameObject stoneTransform2;
    void Start()
    {
        /*Debug.Log(SceneSaverCh.GetDiary());
        Debug.Log(SceneSaverCh.GetDoorOpen());
        Debug.Log(SceneSaverCh.GetKey());
        Debug.Log(SceneSaverCh.GetLight());
        Debug.Log(SceneSaverCh.GetCP());*/
        if(SceneSaverCh.doa && SceneManager.GetActiveScene().name == "Public TestScene")
        {
            var door1Anim = Door1.GetComponent<Animation>();
            door1Anim.Play();
        }
        
        script = itemBar.GetComponent<ItemBar>();
        cameraMovementController = cameraObject.GetComponent<CameraMovementController>();
        sceneSaverCh = cameraObject.GetComponent<SceneSaverCh>();
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

        if (deviceSinkObject)
        {
            deviceSink = deviceSinkObject.GetComponent<DeviceSink>();
        }

        if (flameEffect)
        {
            flameScript = flameEffect.GetComponent<Flame>();
        }

        if (hintObject)
        {
            hintsystem = hintObject.GetComponent<hintsystem>();
        }

        if (SceneSaverCh.CookCrea())
        {
            if (SceneSaverCh.StoneOn2())
            {
                stone2.transform.position = stoneTransform1.transform.position;
                stone2.transform.rotation = stoneTransform1.transform.rotation;
                stone2.transform.localScale = stoneTransform1.transform.localScale;
            }
            else
            {
                int j = 0;
                while (script.ports[j].transform.childCount > 0)
                {
                    j++;
                }
                var ParentPort = GameObject.Find("Port" + j);
                stone2.transform.parent = ParentPort.transform;
                stone2.transform.position = ParentPort.transform.position;
                stone2.transform.localScale = new Vector3(60f, 60f, 60f);
            }
            
        }
        if (SceneSaverCh.EnterCrea())
        {
            if (SceneSaverCh.StoneOn1())
            {
                stone1.transform.position = stoneTransform1.transform.position;
                stone1.transform.rotation = stoneTransform1.transform.rotation;
                stone1.transform.localScale = stoneTransform1.transform.localScale;
            }
            else
            {
                int j = 0;
                while (script.ports[j].transform.childCount > 0)
                {
                    j++;
                }
                var ParentPort = GameObject.Find("Port" + j);
                stone1.transform.parent = ParentPort.transform;
                stone1.transform.position = ParentPort.transform.position;
                stone1.transform.localScale = new Vector3(60f, 60f, 60f);
            }
            
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
            bool isHit = Physics.Raycast(ray, out hit, 100, layerMask); // オーバーライドがたくさんあることに注意すること

            // Ray が当たったかどうかで異なる処理をする1
            if (isHit)
            {
                // Ray が当たった時は、当たった座標まで赤い線を引く
                Debug.DrawLine(ray.origin, hit.point, m_debugRayColorOnHit);
                Debug.Log(hit.collider.name);
                if (hit.collider.tag == "Item" || hit.collider.tag == "Panel")
                {
                    //var itemBar = GameObject.Find("CanvasWorld").transform.Find("ItemBar");
                    var itemObject = hit.collider.gameObject;
                    //var itemScript = itemObject.GetComponent<ThisInfo>();

                    int i = 0;
                    while (script.ports[i].transform.childCount > 0)
                    {
                        i++;
                    }

                    var ParentPort = GameObject.Find("Port" + i);
                    //script.canUseItem[i] = itemObject;
                    var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                    messageText.text = itemObject.name + "を入手した。";
                    messageWindow.SetActive(true);
                    itemObject.layer = LayerMask.NameToLayer("UI");
                    if (itemObject.transform.position == new Vector3(4.12f, 0.761f, -9.346f))
                    {
                        cookingRoomScript.DeviceSink();
                    }
                    itemObject.transform.parent = ParentPort.transform;
                    itemObject.transform.position = ParentPort.transform.position;

                    if (itemObject.name == "Key1" || itemObject.name == "Key2")
                    {
                        itemObject.transform.localScale = new Vector3(100, 100, 100);
                        itemObject.transform.Rotate(new Vector3(180, -90, 0));
                    }
                    else if (itemObject.name == "HintPlane")
                    {
                        itemObject.transform.localScale = new Vector3(6, 1, 6);
                        itemObject.transform.Rotate(new Vector3(-90, 0, 0));
                    }
                    else if (itemObject.name == "HintPlane (1)")
                    {
                        itemObject.transform.localScale = new Vector3(6, 1, 6);
                        itemObject.transform.Rotate(new Vector3(-90, 0, 0));
                    }
                    else if (itemObject.tag == "Panel")
                    {
                        itemObject.transform.localScale = new Vector3(1, 60f, 60f);
                    }
                    else if (itemObject.name == "IceChangesFrom")
                    {
                        itemObject.transform.localScale = new Vector3(135, 100, 135);
                        itemObject.transform.localPosition = new Vector3(6, -30f, 0);
                    }
                    else if (itemObject.name == "KeyObject")
                    {
                        itemObject.transform.localScale = new Vector3(32, 32, 32);
                        itemObject.transform.localPosition = new Vector3(6, -38f, 0);
                    }
                    else if (itemObject.name == "KeyPlateHole")
                    {
                        cookingRoomScript.Freezer_1();
                        cookingRoomScript.Freezer_2();
                        IceKeyPlateClone = cookingRoomScript.KeyPlateHole();
                        itemObject.transform.localScale = new Vector3(270, 270, 270);
                        itemObject.transform.localPosition = new Vector3(0, -17f, 0);
                        if (IceKeyPlateClone != null)
                        {
                            itemObject = IceKeyPlateClone;
                            int j = 0;
                            while (script.ports[j].transform.childCount > 0)
                            {
                                j++;
                            }
                            ParentPort = GameObject.Find("Port" + j);
                            itemObject.transform.parent = ParentPort.transform;
                            itemObject.transform.position = ParentPort.transform.position;
                            messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                            messageText.text = "KeyPlateHoleと氷でできたキープレートを入手した。";
                            messageWindow.SetActive(true);
                            itemObject.layer = LayerMask.NameToLayer("UI");
                            IceKeyPlateClone.transform.localScale = new Vector3(1, 60f, 60f);
                        }
                        

                    }
                    else if(hit.collider.name == "KeyObjectPlateHole")
                    {
                        cookingRoomScript.Freezer_1();
                        cookingRoomScript.Freezer_2();
                        IceKeyObjectClone = cookingRoomScript.KeyObjectPlateHole();
                        itemObject.transform.localScale = new Vector3(270, 270, 270);
                        itemObject.transform.localPosition = new Vector3(0, -17f, 0);
                        if (IceKeyObjectClone != null)
                        {
                            itemObject = IceKeyObjectClone;
                            int j = 0;
                            while (script.ports[j].transform.childCount > 0)
                            {
                                j++;
                            }
                            ParentPort = GameObject.Find("Port" + j);
                            itemObject.transform.parent = ParentPort.transform;
                            itemObject.transform.position = ParentPort.transform.position;
                            messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                            messageText.text = "KeyObjectPlateHoleと氷でできたトロフィープレートを入手した。";
                            messageWindow.SetActive(true);
                            itemObject.layer = LayerMask.NameToLayer("UI");
                            IceKeyObjectClone.transform.localScale = new Vector3(1, 60f, 60f);
                        }

                    }
                    else if (hit.collider.name == "StoneSlab")
                    {
                        stone = true;
                        itemObject.transform.localScale = new Vector3(60f, 60f, 60f);
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
                        SceneSaverCh.doa = true;
                    }
                }

                if (hit.collider.name == "LastDoor")
                {
                    if (SceneSaverCh.StoneOn1() && SceneSaverCh.StoneOn2())
                    {
                        var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                        messageText.text = "扉が開いた";
                        messageWindow.SetActive(true);
                        var bigDoor1Anim = bigDoor1.GetComponent<Animation>();
                        var bigDoor2Anim = bigDoor2.GetComponent<Animation>();
                        var ItemBarScript = itemBar.GetComponent<ItemBar>();
                        bigDoor1Anim.Play();
                        bigDoor2Anim.Play();
                        Invoke("ButtonSyutugen", 3f);
                        clear = true;
                        m_timer = 0;
                    }
                    else
                    {
                        var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                        messageText.text = "鍵がかかっている";
                        messageWindow.SetActive(true);
                    }
                }

                if (hit.collider.tag == "zoom")
                {
                    Debug.Log(cameraMovementController);
                    if (cameraMovementController)
                    {
                        var zoomObject = hit.collider.gameObject;
                        saveBoxCollider = zoomObject.GetComponent<BoxCollider>();
                        saveBoxCollider.enabled = false;
                        var zoomPoint = zoomObject.transform;
                        cameraMovementController.Zoom(zoomPoint);
                    }

                }
                if (hit.collider.tag == "noLinkZoom")
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
                
                if (hit.collider.name == "EnterDoor")
                {
                    if (!SceneSaverCh.EnterCrea())
                    {
                        var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                        messageText.text = "扉が開いた";
                        messageWindow.SetActive(true);
                        sceneSaverCh.SceneSave();
                        Scenechange(enterRoom);
                    }
                    else
                    {
                        var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                        messageText.text = "扉はもう開かない";
                        messageWindow.SetActive(true);
                    }
                    

                }

                if (hit.collider.name == "CookDoor")
                {
                    if (!SceneSaverCh.CookCrea())
                    {
                        var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                        messageText.text = "扉が開いた";
                        messageWindow.SetActive(true);
                        sceneSaverCh.SceneSave();
                        Scenechange(cookRoom);
                    }
                    else
                    {
                        var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                        messageText.text = "扉はもう開かない";
                        messageWindow.SetActive(true);
                    }


                }

                if (hit.collider.name == "door1opening_prefab")
                {
                    if (stone)
                    {
                        var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                        messageText.text = "扉が開いた";
                        messageWindow.SetActive(true);
                        if (SceneManager.GetActiveScene().name == "Cookingroom")
                        {
                            SceneSaverCh.cookingCrea = true;
                        }
                        else if(SceneManager.GetActiveScene().name == "entertainment room")
                        {
                            SceneSaverCh.enterCrea = true;
                        }
                        
                        Scenechange(firstRoom);
                    }
                    else
                    {
                        var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                        messageText.text = "鍵がかかっている";
                        messageWindow.SetActive(true);
                    }
                }


                if (hit.collider.name == "stonePanel1")
                {
                    if(script.selectedItem.name == "StoneSlab")
                    {
                        UseItem();
                        script.selectedItem.transform.position = stoneTransform1.transform.position;
                        script.selectedItem.transform.rotation = stoneTransform1.transform.rotation;
                        script.selectedItem.transform.localScale = stoneTransform1.transform.localScale;
                        script.selectedItem = null;
                        SceneSaverCh.stoneOn1 = true;
                    }
                }
                if (hit.collider.name == "stonePanel2")
                {
                    if (script.selectedItem.name == "StoneSlab")
                    {
                        UseItem();
                        script.selectedItem.transform.position = stoneTransform2.transform.position;
                        script.selectedItem.transform.rotation = stoneTransform2.transform.rotation;
                        script.selectedItem.transform.localScale = stoneTransform2.transform.localScale;
                        script.selectedItem = null;
                        SceneSaverCh.stoneOn2 = true;
                    }
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
                if (hit.collider.name == "DeviceSinkO")
                {
                    if (script.selectedItem != null)
                    {
                        if (script.selectedItem.tag == "Panel")
                        {
                            if (deviceSink.m_SunkItems == null)
                            {
                                UseItem();
                                cookingRoomScript.DeviceSink(selectedPanel);
                                script.selectedItem.transform.localScale = new Vector3(0.2f, 0.05f, 0.2f);
                                script.selectedItem = null;
                            }
                            else
                            {
                                var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                                messageText.text = "すでにプレートが入っています。";
                                messageWindow.SetActive(true);
                            }
                            

                        }
                        else if (script.selectedItem.name == "KeyPlateHole")
                        {
                            UseItem();
                            cookingRoomScript.DeviceSink(script.selectedItem);
                            script.selectedItem.transform.localScale = new Vector3(1f, 1f, 1f);
                            script.selectedItem = null;
                            var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                            messageText.text = "型に水が入った";
                            messageWindow.SetActive(true);
                            //waterIn = true;
                        }
                        else if (script.selectedItem.name == "KeyObjectPlateHole")
                        {
                            UseItem();
                            cookingRoomScript.DeviceSink(script.selectedItem);
                            script.selectedItem.transform.localScale = new Vector3(1f, 1f, 1f);
                            script.selectedItem = null;
                            var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                            messageText.text = "型に水が入った";
                            messageWindow.SetActive(true);
                        }
                        else
                        {
                            var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                            messageText.text = "どうやら水は抜けないようだ";
                            messageWindow.SetActive(true);
                        }
                    }
                    else
                    {
                        var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                        messageText.text = "どうやら水は抜けないようだ";
                        messageWindow.SetActive(true);
                    }


                }

                if (hit.collider.name == "RFAIP_Fridge_Door_Up1")
                {
                    if (cookingRoomScript.m_Freezer_1.Lock)
                    {
                        var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                        messageText.text = "ロックされている";
                        messageWindow.SetActive(true);
                    }
                    else
                    {
                        cookingRoomScript.Freezer_1OpenOrClose();
                    }
                }
                if (hit.collider.name == "RFAIP_Fridge_Door_Up2")
                {
                    if (cookingRoomScript.m_Freezer_2.Lock)
                    {
                        var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                        messageText.text = "ロックされている";
                        messageWindow.SetActive(true);
                    }
                    else
                    {
                        cookingRoomScript.Freezer_2OpenOrClose();
                    }
                }

                if (hit.collider.name == "RFAIPP_Gas_Stove (1)")
                {
                    if (script.selectedItem != null)
                    {
                        if (script.selectedItem.name == "IceChangesFrom")
                        {
                            UseItem();
                            script.selectedItem.transform.localScale = new Vector3(1f, 1f, 1f);
                            script.selectedItem.transform.localPosition = new Vector3(0.879f, 0.95f, -5.8f);
                            flameScript.Burn(script.selectedItem.transform.Find("IceKeyObject").gameObject);
                            script.selectedItem = null;
                            var messageText = messageWindow.transform.GetChild(0).gameObject.GetComponent<Text>();
                            messageText.text = "トロフィーの氷が解けた";
                            messageWindow.SetActive(true);
                        }
                    }
                    
                }

                if (hit.collider.name == "1")
                {
                    if (script.selectedItem != null)
                    {
                        if (script.selectedItem.name == "KeyObject")
                        {
                            UseItem();
                            script.selectedItem.transform.localScale = new Vector3(0.151f, 0.254f, 0.1928f);
                            cookingRoomScript.PedestalSwitchScript(1, script.selectedItem);
                            script.selectedItem.tag = "Untag";
                            script.selectedItem = null;
                        }
                        else if (script.selectedItem.transform.GetChild(0).gameObject.name == "KeyObject")
                        {
                            UseItem();
                            script.selectedItem.transform.localScale = new Vector3(1f, 1f, 1f);
                            cookingRoomScript.PedestalSwitchScript(1, script.selectedItem.transform.GetChild(0).gameObject);
                            script.selectedItem.tag = "Untag";
                            script.selectedItem = null;
                        }
                        
                    }
                    
                }

                if (hit.collider.name == "2")
                {
                    if (script.selectedItem != null)
                    {
                        if (script.selectedItem.name == "KeyObject")
                        {
                            UseItem();
                            script.selectedItem.transform.localScale = new Vector3(0.151f, 0.254f, 0.1928f);
                            cookingRoomScript.PedestalSwitchScript(2, script.selectedItem);
                            script.selectedItem.tag = "Untag";
                            script.selectedItem = null;
                        }
                        else if (script.selectedItem.transform.GetChild(0).gameObject.name == "KeyObject")
                        {
                            UseItem();
                            script.selectedItem.transform.localScale = new Vector3(1f, 1f, 1f);
                            cookingRoomScript.PedestalSwitchScript(2, script.selectedItem.transform.GetChild(0).gameObject);
                            script.selectedItem.tag = "Untag";
                            script.selectedItem = null;
                        }
                        
                    }
                    
                }

                if (hit.collider.name == "Freezer1")
                {
                    if(script.selectedItem != null)
                    {
                        if (script.selectedItem.name == "KeyPlateHole" || script.selectedItem.name == "KeyObjectPlateHole")
                        {
                            UseItem();
                            cookingRoomScript.Freezer_1(script.selectedItem);
                            script.selectedItem.transform.localScale = new Vector3(1, 1, 1);
                            //script.selectedItem.transform.localPosition = new Vector3(4.025f,1.916f,-1.039f);
                            script.selectedItem = null;
                        }
                    }
                    
                }
                if (hit.collider.name == "Freezer2")
                {
                    if (script.selectedItem != null)
                    {
                        if (script.selectedItem.name == "KeyPlateHole" || script.selectedItem.name == "KeyObjectPlateHole")
                        {
                            UseItem();
                            cookingRoomScript.Freezer_2(script.selectedItem);
                            script.selectedItem.transform.localScale = new Vector3(1, 1, 1);
                            script.selectedItem = null;

                        }
                    }
                }

                if (hit.collider.name == "LeftBilliardsTableCamera")
                {
                    if (!left)
                    {
                        hintsystem.Branch++;
                        left = true;
                    }
                }
                if (hit.collider.name == "RightBilliardsTableCamera")
                {
                    if (!right)
                    {
                        hintsystem.Branch++;
                        right = true;
                    }
                }
                if (hit.collider.name == "TableCamera")
                {
                    hintsystem.tableFlag = true;
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
        script.selectedItem.layer = LayerMask.NameToLayer("Default");
        int i = 0;

        while (i < 8)
        {
            script.btns[i].image.color = script.btnColor1;
            i++;
        }
        script.selected = 8;
        script.selectedPort = null;




    }



}

