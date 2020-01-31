using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPlateHole : MonoBehaviour
{
    [SerializeField] GameObject m_Water;
    [SerializeField] GameObject m_Ice;
    [SerializeField] GameObject m_TakeObject;

    private bool pourWater;

    public void PourWater()
    {
        pourWater = true;

        m_Water.SetActive(true);
    }

    public void Freeze()
    {
        if (m_Water.activeSelf)
        {
            m_Ice.SetActive(true);
            m_Water.SetActive(false);
        }
    }

    public GameObject Take()
    {
        if(m_Ice.activeSelf)
        {
            m_Ice.SetActive(false);

          GameObject go  = Instantiate(m_TakeObject);

            go.SetActive(true);

            return go;
        }

        return null;
    }
}
