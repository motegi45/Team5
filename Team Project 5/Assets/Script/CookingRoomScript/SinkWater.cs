using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkWater : MonoBehaviour
{
    /// <summary>シンクの水オブジェクト</summary>
    [SerializeField] GameObject m_SinkWater;
    /// <summary>水速度</summary>
    [SerializeField] float m_WaterSpeed = 0.005f;
    /// <summary>水満タン時のポジション</summary>
    [SerializeField] float m_WaterFilledTankPosition;
    /// <summary>水を全て排水した際のポジション</summary>
    [SerializeField] float m_DrainagePosition;
    /// <summary>水を入れるか排水するか</summary>
    [SerializeField] public bool m_ToWaterOrDrainage = true;
    /// <summary>水の初期位置保存</summary>
    private Vector3 InitialPosition;

    private void Start()
    {
        //水の初期位置保存
        InitialPosition = m_SinkWater.transform.position;
    }

    private void FixedUpdate()
    {
        if(m_ToWaterOrDrainage)
        {
            ToWater();
        }
        else
        {
            Drainage();
        }
    }

    //水を入れる
    private void ToWater()
    {
        Vector3 po = m_SinkWater.transform.position;

        if(po.y < m_WaterFilledTankPosition)
        {
            po.y += m_WaterSpeed;

            if(!(po.y< m_WaterFilledTankPosition))
            {
                po.y = m_WaterFilledTankPosition;
            }
        }
        else
        {
            po.y = m_WaterFilledTankPosition;
        }

        m_SinkWater.transform.position = po;
    }

    private void Drainage()
    {
        Vector3 po = m_SinkWater.transform.position;

        if (po.y > m_DrainagePosition)
        {
            po.y -= m_WaterSpeed;

            if (!(po.y > m_DrainagePosition))
            {
                po.y = m_DrainagePosition;
            }
        }
        else
        {
            po.y = m_DrainagePosition;
        }

        m_SinkWater.transform.position = po;
    }

    /// <summary>ture水を入れる。false排水</summary>
    public void ToWaterOrDrainage(bool b)
    {
        m_ToWaterOrDrainage = b;
    }
        



}
