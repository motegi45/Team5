using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using DG.Tweening;

public class CameraWark : MonoBehaviour
{
    /// <summary></summary>
    [SerializeField] Transform cameraTransform;
    [SerializeField] GameObject left;
    [SerializeField] GameObject right;
    [SerializeField] GameObject up;
    [SerializeField] GameObject down;
    [SerializeField] GameObject down2;
    [SerializeField] GameObject gameManager;
    public float x = 0;
    public float y = 0;
    public float z = 0;
    public bool flagDown = false;
    public bool flagUp = false;


    //special
    public bool backMode = false;
    [SerializeField] public float backY;
    [SerializeField] public float backX;
    [SerializeField] public float backZ;
    public Vector3 savePosition;
    public Quaternion saveRotation;
    float xLange;
    float zLange;
    bool go = false;
    int i = 0;


    //部屋から出る
    [SerializeField] GameObject door;
    [SerializeField] GameObject openButton;
    [SerializeField] GameObject Panel;

    Animator m_anim;

    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
        Panel.SetActive(false);
        savePosition = cameraTransform.position;
        /*xLange = this.transform.position.x - door.transform.position.x;
        zLange = this.transform.position.z - door.transform.position.z;
        xLange = xLange / 60;
        zLange = zLange / 60;*/
        saveRotation = cameraTransform.rotation;
        if (backMode)
        {
            if (saveRotation.w == saveRotation.y)
            {
                cameraTransform.position = new Vector3(savePosition.x - backX, savePosition.y, savePosition.z);
            }
            else if (saveRotation.w == 0)
            {
                cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z + backZ);
            }
            else if (saveRotation.w == -saveRotation.y || -saveRotation.w == saveRotation.y)
            {
                cameraTransform.position = new Vector3(savePosition.x + backX, savePosition.y, savePosition.z);
            }
            else if (saveRotation.w == -1 || saveRotation.w == 1)
            {
                cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z - backZ);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !flagDown && !flagUp)
        {
            //TurnRight();
            //this.transform.DOMove(endValue: new Vector3(savePosition.x - backX, savePosition.y, savePosition.z - backZ), duration: 1.0f);
            saveRotation = cameraTransform.rotation;
            if (backMode)
            {
                float diff = Mathf.Abs(cameraTransform.eulerAngles.y - 90.0f);
                // 0.000002 <= 0.001
                if(diff <= 1)
                {
                    this.transform.DOMove(endValue: new Vector3(savePosition.x, savePosition.y, savePosition.z + backZ), duration: 1.0f);
                }

                diff = Mathf.Abs(cameraTransform.eulerAngles.y + 180.0f);
                // 0.000002 <= 0.001
                if (diff <= 1)
                {
                    this.transform.DOMove(endValue: new Vector3(savePosition.x + backX, savePosition.y, savePosition.z), duration: 1.0f);
                }

                diff = Mathf.Abs(cameraTransform.eulerAngles.y + 90.0f);
                // 0.000002 <= 0.001
                if (diff <= 1)
                {
                    this.transform.DOMove(endValue: new Vector3(savePosition.x, savePosition.y, savePosition.z - backZ), duration: 1.0f);
                }

                if (/*saveRotation.w == saveRotation.y*/cameraTransform.eulerAngles.y == 90)
                {
                    //this.transform.DOMove(endValue: new Vector3(savePosition.x - backX, savePosition.y, savePosition.z), duration: 1.0f);
                    //cameraTransform.position = new Vector3(savePosition.x - backX, savePosition.y, savePosition.z);
                    this.transform.DOMove(endValue: new Vector3(savePosition.x, savePosition.y, savePosition.z + backZ), duration: 1.0f);
                }
                else if (/*saveRotation.w == 0*/cameraTransform.eulerAngles.y == -180)
                {
                    //cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z + backZ);
                    this.transform.DOMove(endValue: new Vector3(savePosition.x + backX, savePosition.y, savePosition.z), duration: 1.0f);
                }
                else if (/*saveRotation.w == -saveRotation.y || -saveRotation.w == saveRotation.y*/cameraTransform.eulerAngles.y == -90)
                {
                    //this.transform.DOMove(endValue: new Vector3(savePosition.x + backX, savePosition.y, savePosition.z), duration: 1.0f);
                    //cameraTransform.position = new Vector3(savePosition.x + backX, savePosition.y, savePosition.z);
                    this.transform.DOMove(endValue: new Vector3(savePosition.x, savePosition.y, savePosition.z - backZ), duration: 1.0f);
                }
                else if (/*saveRotation.w == -1 || saveRotation.w == 1*/cameraTransform.eulerAngles.y == 0)
                {
                    //cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z - backZ);
                    this.transform.DOMove(endValue: new Vector3(savePosition.x - backX, savePosition.y, savePosition.z), duration: 1.0f);
                }
            }
            m_anim.Play("RotateRight");

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !flagUp && !flagDown)
        {
            //TurnLeft();
            m_anim.Play("RotateLeft");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !flagUp)
        {
            TurnUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !flagDown)
        {
            TurnDown();
        }

        /*if (go && i <= 120)
        {
            this.transform.position = new Vector3(this.transform.position.x - xLange, this.transform.position.y, this.transform.position.z - zLange);
            i++;
        }
        if (i >= 120)
        {
            Panel.SetActive(true);
        }*/
    }

    public void TurnRight()
    {
        cameraTransform.position = savePosition;
        y = 90;
        cameraTransform.Rotate(new Vector3(x, y, z));
        x = 0;
        y = 0;
        z = 0;
        //ここから
        saveRotation = cameraTransform.rotation;
        if (backMode)
        {
            if (saveRotation.w == saveRotation.y)
            {
                cameraTransform.position = new Vector3(savePosition.x - backX, savePosition.y, savePosition.z);
            }
            else if (saveRotation.w == 0)
            {
                cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z + backZ);
            }
            else if (saveRotation.w == -saveRotation.y || -saveRotation.w == saveRotation.y)
            {
                cameraTransform.position = new Vector3(savePosition.x + backX, savePosition.y, savePosition.z);
            }
            else if (saveRotation.w == -1 || saveRotation.w == 1)
            {
                cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z - backZ);
            }
        }

    }

    public void TurnLeft()
    {
        cameraTransform.position = savePosition;
        y = -90;
        cameraTransform.Rotate(new Vector3(x, y, z));
        x = 0;
        y = 0;
        z = 0;
        //ここから
        saveRotation = cameraTransform.rotation;
        if (backMode)
        {
            if (saveRotation.w == saveRotation.y)
            {
                cameraTransform.position = new Vector3(savePosition.x - backX, savePosition.y, savePosition.z);
            }
            else if (saveRotation.w == 0)
            {
                cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z + backZ);
            }
            else if (saveRotation.w == -saveRotation.y || -saveRotation.w == saveRotation.y)
            {
                cameraTransform.position = new Vector3(savePosition.x + backX, savePosition.y, savePosition.z);
            }
            else if (saveRotation.w == -1 || saveRotation.w == 1)
            {
                cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z - backZ);
            }
        }
    }

    public void TurnUp()
    {
        cameraTransform.position = savePosition;
        if (!flagUp && !flagDown)
        {
            x = -90;
            cameraTransform.Rotate(new Vector3(x, y, z));
            x = 0;
            y = 0;
            z = 0;
            left.SetActive(false);
            right.SetActive(false);
            up.SetActive(false);
            flagUp = true;
            if (backMode)
            {
                cameraTransform.position = new Vector3(savePosition.x, savePosition.y - backY, savePosition.z);
            }
        }
        else if (flagDown)
        {
            BarOpen openScript = gameManager.GetComponent<BarOpen>();
            x = -90;
            cameraTransform.Rotate(new Vector3(x, y, z));
            x = 0;
            y = 0;
            z = 0;
            left.SetActive(true);
            right.SetActive(true);
            if (openScript.flag)
            {
                down.SetActive(true);
            }
            else if (!openScript.flag)
            {
                down2.SetActive(true);
            }
            flagDown = false;
            saveRotation = cameraTransform.rotation;
            if (backMode)
            {
                if (saveRotation.w == saveRotation.y)
                {
                    cameraTransform.position = new Vector3(savePosition.x - backX, savePosition.y, savePosition.z);
                }
                else if (saveRotation.w == 0)
                {
                    cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z + backZ);
                }
                else if (saveRotation.w == -saveRotation.y || -saveRotation.w == saveRotation.y)
                {
                    cameraTransform.position = new Vector3(savePosition.x + backX, savePosition.y, savePosition.z);
                }
                else if (saveRotation.w == -1 || saveRotation.w == 1)
                {
                    cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z - backZ);
                }
            }
        }


    }

    public void TurnDown()
    {
        cameraTransform.position = savePosition;
        if (!flagDown && !flagUp)
        {

            cameraTransform.DORotate(endValue: new Vector3(90f, saveRotation.y, saveRotation.z), duration: 1.0f, mode: RotateMode.FastBeyond360);
            x = 90;
            cameraTransform.Rotate(new Vector3(x, y, z));
            x = 0;
            y = 0;
            z = 0;
            left.SetActive(false);
            right.SetActive(false);
            down.SetActive(false);
            down2.SetActive(false);
            flagDown = true;
            if (backMode)
            {
                cameraTransform.position = new Vector3(savePosition.x, savePosition.y + backY, savePosition.z);
            }
        }
        else if (flagUp)
        {
            x = 90;
            cameraTransform.Rotate(new Vector3(x, y, z));
            x = 0;
            y = 0;
            z = 0;
            left.SetActive(true);
            right.SetActive(true);
            up.SetActive(true);
            flagUp = false;
            saveRotation = cameraTransform.rotation;
            if (backMode)
            {
                if (saveRotation.w == saveRotation.y)
                {
                    cameraTransform.position = new Vector3(savePosition.x - backX, savePosition.y, savePosition.z);
                }
                else if (saveRotation.w == 0)
                {
                    cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z + backZ);
                }
                else if (saveRotation.w == -saveRotation.y || -saveRotation.w == saveRotation.y)
                {
                    cameraTransform.position = new Vector3(savePosition.x + backX, savePosition.y, savePosition.z);
                }
                else if (saveRotation.w == -1 || saveRotation.w == 1)
                {
                    cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z - backZ);
                }
            }
        }
    }

    public void Goto()
    {
        go = true;
        if (go)
        {
            this.transform.DOMove(endValue: new Vector3(-0.16f, this.transform.position.y, -3.267f), duration: 5.0f);
        }
        /*
        for (int i = 0; i < 300; i++)//this.transform.position == door.transform.position)
        {
            var xLange = this.transform.position.x - door.transform.position.x;
            //var yLange = this.transform.position.y - door.transform.position.y;
            var zLange = this.transform.position.z - door.transform.position.z;
            xLange = xLange / 300;
            //yLange = yLange / 300000;
            zLange = zLange / 300;
            this.transform.position = new Vector3(this.transform.position.x + xLange,this.transform.position.y,this.transform.position.z + zLange);
            
        }
        */

    }
}

