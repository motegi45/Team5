using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] Transform[] m_cameraPoints;
    [SerializeField] Transform[] m_cameraPoints2;
    [SerializeField] Transform[] m_cameraPoints3;
    [SerializeField] Transform[] m_cameraPoints4;

    [SerializeField] float m_moveTime = 1.0f;
    int m_cameraPointIndex;
    [SerializeField] Transform m_cameraPinPoint;
    Transform saveTransform;
    bool upFlag = false;
    public bool itemBarPossible = true;
    bool zoomNow = false;
    public int info = 1;
    [SerializeField] Transform hint;
    [SerializeField] GameObject gameManager;
    RaycastController raycastController;

    /// <summary>baropenより</summary>
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject itemBar;
    [SerializeField] GameObject panelIB;
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    public bool itemflag = false;
    /// <summary>まで</summary>

    void Start()
    {
        raycastController = gameManager.GetComponent<RaycastController>();
        var hintsystem = hint.GetComponent<hintsystem>();
    }

    void Update()
    {

        ///カメラの動きを制限
        //テスト用
        if (Input.GetKeyDown(KeyCode.P))
        {
            info++;
            if (info == 2)
            {
                SmoothMove(m_cameraPoints2[2]);
            }
            if (info == 3)
            {
                SmoothMove(m_cameraPoints3[2]);
            }
            if (info == 4)
            {
                SmoothMove(m_cameraPoints4[2]);
            }


        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            info--;
            if (info == 1)
            {
                SmoothMove(m_cameraPoints[2]);
            }
            if (info == 2)
            {
                SmoothMove(m_cameraPoints2[2]);
            }
            if (info == 3)
            {
                SmoothMove(m_cameraPoints3[2]);
            }
        }
        
        if (info == 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!zoomNow && !upFlag)
                {
                    m_cameraPinPoint.Rotate(new Vector3(0, 0, 90));
                    m_cameraPointIndex = (m_cameraPointIndex + 1) % m_cameraPoints.Length;
                    SmoothMove(m_cameraPoints[m_cameraPointIndex]);
                }
                   
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!zoomNow && !upFlag)
                {
                    m_cameraPinPoint.Rotate(new Vector3(0, 0, -90));
                    m_cameraPointIndex = (m_cameraPointIndex - 1 + m_cameraPoints.Length) % m_cameraPoints.Length;
                    SmoothMove(m_cameraPoints[m_cameraPointIndex]);
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (!zoomNow && !upFlag)
                {
                    saveTransform = m_cameraPoints[m_cameraPointIndex];
                    SmoothMove(m_cameraPinPoint);
                    upFlag = true;
                }
                    
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (zoomNow)
                {
                    ZoomOut();
                }
                else if (upFlag)
                {
                    SmoothMove(saveTransform);
                    upFlag = false;

                }
            }
        }
        if (info == 2)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!zoomNow && !upFlag)
                {
                    m_cameraPinPoint.Rotate(new Vector3(0, 0, 90));
                    m_cameraPointIndex = (m_cameraPointIndex + 1) % m_cameraPoints2.Length;
                    SmoothMove(m_cameraPoints2[m_cameraPointIndex]);
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!zoomNow && !upFlag)
                {
                    m_cameraPinPoint.Rotate(new Vector3(0, 0, -90));
                    m_cameraPointIndex = (m_cameraPointIndex - 1 + m_cameraPoints2.Length) % m_cameraPoints2.Length;
                    SmoothMove(m_cameraPoints2[m_cameraPointIndex]);
                }
                    
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (!zoomNow && !upFlag)
                {
                    saveTransform = m_cameraPoints2[m_cameraPointIndex];
                    SmoothMove(m_cameraPinPoint);
                    upFlag = true;
                }
                    
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (upFlag)
                {
                    SmoothMove(saveTransform);
                    upFlag = false;

                }
            }
        }
        if (info == 3)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!zoomNow && !upFlag)
                {
                    m_cameraPinPoint.Rotate(new Vector3(0, 0, 90));
                    m_cameraPointIndex = (m_cameraPointIndex + 1) % m_cameraPoints3.Length;
                    SmoothMove(m_cameraPoints3[m_cameraPointIndex]);
                }
                   
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!zoomNow && !upFlag)
                {
                    m_cameraPinPoint.Rotate(new Vector3(0, 0, -90));
                    m_cameraPointIndex = (m_cameraPointIndex - 1 + m_cameraPoints3.Length) % m_cameraPoints3.Length;
                    SmoothMove(m_cameraPoints3[m_cameraPointIndex]);
                }
                    
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (!zoomNow && !upFlag)
                {
                    saveTransform = m_cameraPoints3[m_cameraPointIndex];
                    SmoothMove(m_cameraPinPoint);
                    upFlag = true;
                }
                    
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (upFlag)
                {
                    SmoothMove(saveTransform);
                    upFlag = false;

                }
            }

        }
        if (info == 4)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!zoomNow && !upFlag)
                {
                    m_cameraPinPoint.Rotate(new Vector3(0, 0, 90));
                    m_cameraPointIndex = (m_cameraPointIndex + 1) % m_cameraPoints4.Length;
                    SmoothMove(m_cameraPoints4[m_cameraPointIndex]);
                }
                    
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!zoomNow && !upFlag)
                {
                    m_cameraPinPoint.Rotate(new Vector3(0, 0, -90));
                    m_cameraPointIndex = (m_cameraPointIndex - 1 + m_cameraPoints4.Length) % m_cameraPoints4.Length;
                    SmoothMove(m_cameraPoints4[m_cameraPointIndex]);
                }
                    
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (!zoomNow && !upFlag)
                {
                    saveTransform = m_cameraPoints4[m_cameraPointIndex];
                    SmoothMove(m_cameraPinPoint);
                    upFlag = true;
                }
                    
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (upFlag)
                {
                    SmoothMove(saveTransform);
                    upFlag = false;

                }
            }
        }
        if (Input.GetKeyDown("1") || Input.GetMouseButtonDown(1))
        {
            OpenClose();
        }
        if (upFlag == true || zoomNow == true)
        {
            Panel.SetActive(false);
            if (itemflag)
            {
                button2.SetActive(false);
                button1.SetActive(true);
                panelIB.SetActive(true);
                itemBar.SetActive(true);
            }
            else
            {
                button1.SetActive(false);
                button2.SetActive(true);
                panelIB.SetActive(false);
                itemBar.SetActive(false);
            }
        }
        else
        {
            Panel.SetActive(true);
            if (itemflag)
            {
                button2.SetActive(false);
                button1.SetActive(false);
                panelIB.SetActive(true);
                itemBar.SetActive(true);
            }
            else
            {
                button1.SetActive(false);
                button2.SetActive(false);
                panelIB.SetActive(false);
                itemBar.SetActive(false);
            }

        }
    }
    //ボタン用の関数
    public void RightButton()
    {
        if (info == 1)
        {
            m_cameraPinPoint.Rotate(new Vector3(0, 0, 90));
            m_cameraPointIndex = (m_cameraPointIndex + 1) % m_cameraPoints.Length;
            SmoothMove(m_cameraPoints[m_cameraPointIndex]);
        }
        else if (info == 2)
        {
            m_cameraPinPoint.Rotate(new Vector3(0, 0, 90));
            m_cameraPointIndex = (m_cameraPointIndex + 1) % m_cameraPoints2.Length;
            SmoothMove(m_cameraPoints2[m_cameraPointIndex]);
        }
        else if (info == 3)
        {
            m_cameraPinPoint.Rotate(new Vector3(0, 0, 90));
            m_cameraPointIndex = (m_cameraPointIndex + 1) % m_cameraPoints3.Length;
            SmoothMove(m_cameraPoints3[m_cameraPointIndex]);
        }
        else if (info == 4)
        {
            m_cameraPinPoint.Rotate(new Vector3(0, 0, 90));
            m_cameraPointIndex = (m_cameraPointIndex + 1) % m_cameraPoints4.Length;
            SmoothMove(m_cameraPoints4[m_cameraPointIndex]);
        }

    }

    public void LeftButton()
    {
        if (info == 1)
        {
            m_cameraPinPoint.Rotate(new Vector3(0, 0, -90));
            m_cameraPointIndex = (m_cameraPointIndex - 1 + m_cameraPoints.Length) % m_cameraPoints.Length;
            SmoothMove(m_cameraPoints[m_cameraPointIndex]);
        }
        else if (info == 2)
        {
            m_cameraPinPoint.Rotate(new Vector3(0, 0, -90));
            m_cameraPointIndex = (m_cameraPointIndex - 1 + m_cameraPoints2.Length) % m_cameraPoints2.Length;
            SmoothMove(m_cameraPoints2[m_cameraPointIndex]);
        }
        else if (info == 3)
        {
            m_cameraPinPoint.Rotate(new Vector3(0, 0, -90));
            m_cameraPointIndex = (m_cameraPointIndex - 1 + m_cameraPoints3.Length) % m_cameraPoints3.Length;
            SmoothMove(m_cameraPoints3[m_cameraPointIndex]);
        }
        else if (info == 4)
        {
            m_cameraPinPoint.Rotate(new Vector3(0, 0, -90));
            m_cameraPointIndex = (m_cameraPointIndex - 1 + m_cameraPoints4.Length) % m_cameraPoints4.Length;
            SmoothMove(m_cameraPoints4[m_cameraPointIndex]);
        }

    }

    public void UpButton()
    {
        if (info == 1)
        {
            saveTransform = m_cameraPoints[m_cameraPointIndex];
            SmoothMove(m_cameraPinPoint);
            upFlag = true;
        }
        else if (info == 2)
        {

        }
        else if (info == 3)
        {

        }
        else if (info == 4)
        {

        }

    }

    public void DownButton()
    {
        if (info == 1)
        {
            if (upFlag)
            {
                SmoothMove(saveTransform);
                upFlag = false;
            }
        }
        else if (info == 2)
        {

        }
        else if (info == 3)
        {

        }
        else if (info == 4)
        {

        }

    }

    public void Zoom(Transform target)
    {
        if (!zoomNow)
        {
            saveTransform = m_cameraPoints[m_cameraPointIndex];
            SmoothMove(target);
            zoomNow = true;
        }
    }

    public void SmoothMove(Transform target)
    {
        transform.DOLocalMove(target.transform.position, m_moveTime);
        transform.DORotateQuaternion(target.transform.rotation, m_moveTime);
    }

    public void ZoomOut()
    {
        transform.DOLocalMove(saveTransform.transform.position, m_moveTime);
        transform.DORotateQuaternion(saveTransform.transform.rotation, m_moveTime);
        zoomNow = false;
        raycastController.saveBoxCollider.enabled = true;
    }

    public void OpenClose()
    {
        itemflag = !itemflag;
    }
}

