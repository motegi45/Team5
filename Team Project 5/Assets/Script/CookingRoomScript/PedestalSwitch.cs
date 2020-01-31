using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalSwitch : MonoBehaviour
{
    /// <summary>台座にするオブジェクト</summary>
    [SerializeField] GameObject[] m_Pedestal;
    /// <summary>台座に乗せる事で台座を沈ませるオブジェクトの名前</summary>
    [SerializeField] string m_NameOfObjectToPut= "KeyObject";
    /// <summary>台座に乗せるオブジェクト</summary>
    [SerializeField] GameObject[] m_PedestalToPutOn;
    /// <summary>台座からどれだけずれた位置に乗せるオブジェクトを置くか</summary>
    [SerializeField] Vector3 m_Difference=new Vector3(0, 0.05f, 0);
    /// <summary>最大移動距離</summary>
    [SerializeField] float m_MaximumTravel=0.09f;
    /// <summary>台座が沈む速度</summary>
    [SerializeField] float m_Speed=0.005f;
    /// <summary>台座のデフォルトの位置情報保存</summary>
    private Vector3[] DefaultPosition;
    /// <summary>石板オブジェクト</summary>
    [SerializeField] GameObject m_StoneSlab;

    private void Start()
    {
        //謎を解くまで石板を入手できないようにするため非表示にする
        m_StoneSlab.SetActive(false);

        //台座の数に合わせる
       // m_PedestalToPutOn = new GameObject[m_Pedestal.Length];

        //台座のデフォルト位置を保存する
        DefaultPosition = new Vector3[m_Pedestal.Length];
        for (int i=0;i< m_Pedestal.Length;i++)
        {
            DefaultPosition[i] = m_Pedestal[i].transform.position;
        }
    }

    private void FixedUpdate()
    {
        PedestalCaveIn();

        InitialPlacementReturn();

        MoveAlongThePedestal();

        EmergenceStoneSlab();
    }

    //全ての台座に鍵となるオブジェクトが乗った時石板を出現させる
    private void EmergenceStoneSlab()
    {
        for (int i = 0; i < m_Pedestal.Length; i++)
        {
            //nullか相応しいオブジェクトじゃない場合即終了する
            if (m_PedestalToPutOn[i] == null|| m_PedestalToPutOn[i].name != m_NameOfObjectToPut)
            {
                break;
            }

            //最後のオブジェクトが相応しいオブジェクトの場合石板を出現させる
            if (i == (m_Pedestal.Length - 1))
            {
                if (m_PedestalToPutOn[i].name == m_NameOfObjectToPut)
                {
                    m_StoneSlab.SetActive(true);
                }
            }
        }
    }

    //相応しいオブジェクトが置かれた時台座を沈める
    private void PedestalCaveIn()
    {
        for (int i = 0; i < m_Pedestal.Length; i++)
        {
            //相応しいオブジェクトが置かれた場合、一定の速度で沈める
            if (m_PedestalToPutOn[i] != null)
            {
                if (m_PedestalToPutOn[i].name == m_NameOfObjectToPut)
                {
                    Vector3 pt = m_Pedestal[i].transform.position;
                    pt.y -= m_Speed;

                    //上限以上沈んだ場合、沈める上限値にする
                    if (pt.y < (DefaultPosition[i].y - m_MaximumTravel))
                    {
                        pt.y = (DefaultPosition[i].y - m_MaximumTravel);
                    }

                    m_Pedestal[i].transform.position = pt;
                }
            }
        }
    }

    //相応しいオブジェクトが置かれていない時台座を初期位置に戻す
    private void InitialPlacementReturn()
    {
        for (int i = 0; i < m_Pedestal.Length; i++)
        {
            if (m_PedestalToPutOn[i] != null)
            {
                if (m_PedestalToPutOn[i].name != m_NameOfObjectToPut)
                {
                    m_Pedestal[i].transform.position = DefaultPosition[i];
                }
            }
        }
    }

    //乗せるオブジェクトを台座に合わせてポジションを移動させる
    private void MoveAlongThePedestal()
    {
        for (int i = 0; i < m_Pedestal.Length; i++)
        {
            if (m_PedestalToPutOn[i]!=null)
            {
                m_PedestalToPutOn[i].transform.position = (m_Pedestal[i].transform.position + m_Difference);
            }
        }
    }

    //乗せるオブジェクトを配列に入れる
    public GameObject PutOnThePedestal(int num,GameObject go)
    {
        //配列に何もなければオブジェクトを入れるあれば交換する
        if((num < m_PedestalToPutOn.Length)&& num >= 0)
        {
           if(m_PedestalToPutOn[num]==null)
            {
                m_PedestalToPutOn[num] = go;

                return null;
            }
           else
            {
               GameObject thisGo = m_PedestalToPutOn[num];

                m_PedestalToPutOn[num] = go;

                return thisGo;
            }
        }

        return go;
    }

    //乗せるオブジェクトを配列から出す
    public GameObject TakeObject(int num)
    {
        if ((num < m_PedestalToPutOn.Length) && num >= 0)
        {
            if (m_PedestalToPutOn[num] != null)
            {
                GameObject go= m_PedestalToPutOn[num];

                m_PedestalToPutOn[num] = null;

                return go;
            }
        }

        return null;
    }

}
