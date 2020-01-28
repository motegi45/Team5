using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] Transform[] m_cameraPoints;
    [SerializeField] float m_moveTime = 1.0f;
    int m_cameraPointIndex;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_cameraPointIndex = (m_cameraPointIndex + 1) % m_cameraPoints.Length;
            SmoothMove(m_cameraPoints[m_cameraPointIndex]);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_cameraPointIndex = (m_cameraPointIndex - 1 + m_cameraPoints.Length) % m_cameraPoints.Length;
            SmoothMove(m_cameraPoints[m_cameraPointIndex]);
        }
    }

    void SmoothMove(Transform target)
    {
        transform.DOLocalMove(target.transform.position, m_moveTime);
        transform.DORotateQuaternion(target.transform.rotation, m_moveTime);
    }
}
