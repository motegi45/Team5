using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    /// <summary>IceKeyObjectが来た時に渡すオブジェクト</summary>
    [SerializeField] GameObject m_KeyGo;

    public GameObject Burn(GameObject go)
    {
        if(go.name == "IceKeyObject")
        {
            Destroy(go);
            m_KeyGo.SetActive(true);
               return m_KeyGo;
        }

        return null;
    }


    
}
