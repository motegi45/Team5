using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] Transform[] m_cameraPoints;
    [SerializeField] float m_moveTime = 1.0f;
    int m_cameraPointIndex;

    [SerializeField] Transform m_cameraPinPoint;
    Transform saveTransform;
    bool upFlag = false;
    public bool itemBarPossible = true;
    bool zoomNow = false;


    void Start()
    {

    }

    void Update()
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

    //ボタン用の関数
    public void RightButton()
    {
        m_cameraPinPoint.Rotate(new Vector3(0, 0, 90));
        m_cameraPointIndex = (m_cameraPointIndex + 1) % m_cameraPoints.Length;
        SmoothMove(m_cameraPoints[m_cameraPointIndex]);
    }

    public void LeftButton()
    {
        m_cameraPinPoint.Rotate(new Vector3(0, 0, -90));
        m_cameraPointIndex = (m_cameraPointIndex - 1 + m_cameraPoints.Length) % m_cameraPoints.Length;
        SmoothMove(m_cameraPoints[m_cameraPointIndex]);
    }

    public void UpButton()
    {
        saveTransform = m_cameraPoints[m_cameraPointIndex];
        SmoothMove(m_cameraPinPoint);
        upFlag = true;
    }

    public void DownButton()
    {
        if (upFlag)
        {
            SmoothMove(saveTransform);
            upFlag = false;
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
    }
}
