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
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject Panel2;
    [SerializeField] Transform m_cameraPinPoint;
    Transform saveTransform;
    bool upFlag = false;
    public bool itemBarPossible = true;
    bool zoomNow = false;
    public int info = 1;



    void Start()
    {
        //Panel2.SetActive(false);
    }

    void Update()
    {
        //テスト用
        if (Input.GetKeyDown(KeyCode.P))
        {
            info++;
            if(info == 2)
            {
                SmoothMove(m_cameraPoints2[2]);
            }
            if(info == 3)
            {
                SmoothMove(m_cameraPoints3[2]);
            }
            if(info == 4)
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
        //
        if (info == 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                m_cameraPinPoint.Rotate(new Vector3(0, 0, 90));
                m_cameraPointIndex = (m_cameraPointIndex + 1) % m_cameraPoints.Length;
                SmoothMove(m_cameraPoints[m_cameraPointIndex]);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                m_cameraPinPoint.Rotate(new Vector3(0, 0, -90));
                m_cameraPointIndex = (m_cameraPointIndex - 1 + m_cameraPoints.Length) % m_cameraPoints.Length;
                SmoothMove(m_cameraPoints[m_cameraPointIndex]);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                saveTransform = m_cameraPoints[m_cameraPointIndex];
                SmoothMove(m_cameraPinPoint);
                upFlag = true;
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
        if (info == 2)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                m_cameraPinPoint.Rotate(new Vector3(0, 0, 90));
                m_cameraPointIndex = (m_cameraPointIndex + 1) % m_cameraPoints2.Length;
                SmoothMove(m_cameraPoints2[m_cameraPointIndex]);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                m_cameraPinPoint.Rotate(new Vector3(0, 0, -90));
                m_cameraPointIndex = (m_cameraPointIndex - 1 + m_cameraPoints2.Length) % m_cameraPoints2.Length;
                SmoothMove(m_cameraPoints2[m_cameraPointIndex]);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                saveTransform = m_cameraPoints2[m_cameraPointIndex];
                SmoothMove(m_cameraPinPoint);
                upFlag = true;
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
                m_cameraPinPoint.Rotate(new Vector3(0, 0, 90));
                m_cameraPointIndex = (m_cameraPointIndex + 1) % m_cameraPoints3.Length;
                SmoothMove(m_cameraPoints3[m_cameraPointIndex]);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                m_cameraPinPoint.Rotate(new Vector3(0, 0, -90));
                m_cameraPointIndex = (m_cameraPointIndex - 1 + m_cameraPoints3.Length) % m_cameraPoints3.Length;
                SmoothMove(m_cameraPoints3[m_cameraPointIndex]);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                saveTransform = m_cameraPoints3[m_cameraPointIndex];
                SmoothMove(m_cameraPinPoint);
                upFlag = true;
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
                m_cameraPinPoint.Rotate(new Vector3(0, 0, 90));
                m_cameraPointIndex = (m_cameraPointIndex + 1) % m_cameraPoints4.Length;
                SmoothMove(m_cameraPoints4[m_cameraPointIndex]);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                m_cameraPinPoint.Rotate(new Vector3(0, 0, -90));
                m_cameraPointIndex = (m_cameraPointIndex - 1 + m_cameraPoints4.Length) % m_cameraPoints4.Length;
                SmoothMove(m_cameraPoints4[m_cameraPointIndex]);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                saveTransform = m_cameraPoints4[m_cameraPointIndex];
                SmoothMove(m_cameraPinPoint);
                upFlag = true;
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
            Panel.SetActive(false);
            Panel2.SetActive(true);
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
        Panel.SetActive(true);
        Panel2.SetActive(false);
    }
}

