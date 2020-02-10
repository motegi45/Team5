using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceSink : MonoBehaviour
{
    /// <summary>沈ませているアイテム</summary>
    [SerializeField] public GameObject m_SunkItems;
    /// <summary>沈ませる場所</summary>
    [SerializeField] Vector3 SinkingPlace;
    /// <summary>炎スクリプト</summary>
    [SerializeField] FlameEffect m_FlameEffect;
     /// <summary>冷凍庫スクリプト</summary>
    [SerializeField] Freezer m_Freezer_1;
    /// <summary>冷凍庫スクリプト</summary>
    [SerializeField] Freezer m_Freezer_2;

    /// <summary></summary>
    [SerializeField] GameObject m_KeyObject;
    /// <summary></summary>

    /// <summary></summary>

    private void FixedUpdate()
    {
        //この場所で沈ませる
        if(m_SunkItems != null)
        {
            m_SunkItems.transform.position = SinkingPlace;
        }
        
        GimmickRelease();

        StartingTheDevice();
    }

    //保持するオブジェクトの名前に応じて仕掛けを発動する
    private void StartingTheDevice()
    {
        if(m_SunkItems!=null)
        {
            switch (m_SunkItems.name)
            {
                case "FlamePlate":
                    m_FlameEffect.EffectSwitch = true;
                    break;
                case "KeyPlate":
                    m_Freezer_1.Lock = false;
                    break;
                case "IceKeyPlate(Clone)":
                    m_Freezer_2.Lock = false;
                    break;
                case "IceKeyObjectPlate(Clone)":
                    m_KeyObject.SetActive(true);
                    break;
                case "KeyObjectPlateHole":
                    m_SunkItems.GetComponent<KeyPlateHole>().PourWater();
                    break;
                case "KeyPlateHole":
                    m_SunkItems.GetComponent<KeyPlateHole>().PourWater();

                    break;
            }

        }
    }

    //発動したギミックの解除
    private void GimmickRelease()
    {
        m_FlameEffect.EffectSwitch = false;
        m_Freezer_1.Lock = true;
        m_Freezer_2.Lock = true;

    }

    //アイテムを変数に入れる、すでにある場合交換する
    public GameObject ReceivingItems(GameObject go)
    {
        if(m_SunkItems == null)
        {
            m_SunkItems = go;
        }
        else
        {
            GameObject go_2= m_SunkItems;
            m_SunkItems = go;

            return go_2;
        }


        return null;
    }

    //アイテムを渡す
    public GameObject ItemPass()
    {
       GameObject go= m_SunkItems;

        m_SunkItems = null;

        return go;
    }

}
