using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    [SerializeField] GameObject m_Arrangement;
    [SerializeField] Transform m_ArrangementLocation;
    /// <summary>開け口</summary>
    [SerializeField] GameObject m_OpeningObject;
    /// <summary>開け口</summary>
    [SerializeField] Transform m_Axis;
    /// <summary>閉じたときの回転</summary>
    [SerializeField] Vector3 m_CloseRotationValue;
    /// <summary>開けた時の回転</summary>
    [SerializeField] Vector3 m_OpenRotationValue;
    /// <summary>速度</summary>
    [SerializeField] Vector3 m_Speed = new Vector3(0,1,0);
    /// <summary>閉めている</summary>
    public bool closed = true;
    /// <summary>開けるか閉めるか</summary>
   // public bool Open { get; set; } = false;
    private bool open  = false;
    /// <summary>鍵をかける</summary>
    public bool Lock  = true;

    private void FixedUpdate()
    {
        if (closed)
        {
            if (m_Arrangement != null)
            {
                if (m_Arrangement.name == "KeyObjectPlateHole" || m_Arrangement.name == "KeyPlateHole")
                {
                    m_Arrangement.GetComponent<KeyPlateHole>().Freeze();

                    closed = false;
                }
            }
        }

        if (open && !Lock)
        {
            Opening();
        }
        else
        {
            Closeing();
        }
    }

    //開ける
    private void Opening()
    {
        closed = false;

        Vector3 rotation = m_Axis.eulerAngles;

        rotation.y= ValueGetCloser(rotation.y, m_OpenRotationValue.y, m_Speed.y);
        rotation.x = ValueGetCloser(rotation.x, m_OpenRotationValue.x, m_Speed.x);
        rotation.z = ValueGetCloser(rotation.z, m_OpenRotationValue.z, m_Speed.z);

        m_Axis.rotation = Quaternion.Euler(rotation);
    }

    //閉める
    private void Closeing()
    {
        Vector3 rotation = m_Axis.eulerAngles;

        rotation.y = ValueGetCloser(rotation.y, m_CloseRotationValue.y, m_Speed.y);
        rotation.x = ValueGetCloser(rotation.x, m_CloseRotationValue.x, m_Speed.x);
        rotation.z = ValueGetCloser(rotation.z, m_CloseRotationValue.z, m_Speed.z);

        if(rotation.y == m_CloseRotationValue.y)
        {
            closed = true;
        }
        
        m_Axis.rotation = Quaternion.Euler(rotation);
    }

    //特定の値に近づける
    private float ValueGetCloser(float rotation,float purpose,float speed)
    {

        if (rotation == purpose)
        {

        }
        else if (rotation > purpose)
        {
            rotation -= speed;

            if(rotation <= purpose)
            {
                rotation = purpose;
            }
        }
        else if (rotation < purpose)
        {

            rotation += speed;

            if (rotation >= purpose)
            {
                rotation = purpose;
            }
        }

        return rotation;

    }

    public GameObject Arrangement(GameObject go)
    {
        if(m_Arrangement == null)
        {
            m_Arrangement = go;

            m_Arrangement.transform.position = m_ArrangementLocation.position;

            return null;
        }

        GameObject go1 = m_Arrangement;
        m_Arrangement = go;
        return go1;
    }

    public GameObject Take()
    {
        GameObject go = m_Arrangement;

        m_Arrangement = null;

        return go;
    }

    public void OpenOrClose()
    {
        if(open)
        {
            open = false;
        }
        else
        {
            open = true;
        }
    }

    public void OpenOrClose(bool b)
    {
        open = b;
    }
}
