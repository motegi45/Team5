using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingRoomScript : MonoBehaviour
{
    [SerializeField] PedestalSwitch m_PedestalSwitchScript;
    [SerializeField] SinkWater m_Sink_1;
    [SerializeField] SinkWater m_Sink_2;
    [SerializeField] DeviceSink m_DeviceSink;
    [SerializeField] KeyPlateHole m_KeyPlateHole;
    [SerializeField] KeyPlateHole m_KeyObjectPlateHole;
    [SerializeField] Freezer m_Freezer_1;
    [SerializeField] Freezer m_Freezer_2;

    /// <summary>
    /// この関数では台のオブジェクトを受け渡し出来ます。
    /// <para>関数(台の番号(int),置くオブジェクト(GameObject))。</para>
    /// <para>戻り値(GameObject)、既に何かある場合交換、なければnull。</para>
    /// <para>引数の「置くオブジェクト」を省くと、オブジェクトを一方的に受け取ることができます。</para>
    /// </summary>
    /// <param name="i">台の番号(配列番号)</param>
    /// <param name="go">渡すオブジェクト</param>
    public GameObject PedestalSwitchScript(int i, GameObject go)
    {
        return m_PedestalSwitchScript.PutOnThePedestal(i, go);
    }
    /// <summary>
    /// この関数では台のオブジェクトを受けとることが出来ます。
    /// <para>関数(台の番号(int))</para>
    /// <para>戻り値(GameObject)、台にあるオブジェクトを渡す、なければnull</para>
    /// <para>引数に 関数(台の番号(int),置くオブジェクト(GameObject)) を追加すると、オブジェクトを受け渡しすることができます。</para>
    /// </summary>
    /// <param name="i">台の番号(配列番号)</param>
    public GameObject PedestalSwitchScript(int i)
    {
        return m_PedestalSwitchScript.TakeObject(i);
    }

    /// <summary>
    /// この関数ではシンクの水を入れる、又は排水が出来ます。
    /// <para>関数(水を入れる、排水(bool))</para>
    /// <para>戻り値無し。</para>
    /// </summary>
    /// <param name="b">ture水を入れる。false排水</param>
    public void Sink_1(bool b)
    {
        m_Sink_1.ToWaterOrDrainage(b);
    }

    /// <summary>
    /// この関数ではシンクの水を入れる、又は排水が出来ます。
    /// <para>関数(水を入れる、排水(bool))</para>
    /// <para>戻り値無し。</para>
    /// </summary>
    /// <param name="b">ture水を入れる。false排水</param>
    public void Sink_2(bool b)
    {
        m_Sink_2.ToWaterOrDrainage(b);
    }

    /// <summary>
    /// この関数では仕掛けシンクのオブジェクトを取り出すことが出来ます。
    /// <para>関数()</para>
    /// <para>戻り値(GameObject)、シンクにあるオブジェクトを返す、なければnull</para>
    /// <para>引数にGameObjectを追加するとシンクにオブジェクトを入れることができます。</para>
    /// </summary>
    /// <returns></returns>
    public GameObject DeviceSink()
    {
       return m_DeviceSink.ItemPass();
    }


    /// <summary>
    /// この関数では仕掛けシンクにオブジェクトを入れることが出来ます。既にある場合交換します。
    /// <para>関数(入れるオブジェクト(GameObject))</para>
    /// <para>戻り値(GameObject)、シンクにあるオブジェクトを渡す、なければnull</para>
    /// <para>引数にGameObjectを追加するとシンクにオブジェクトを入れることができます。</para>
    /// </summary>
    /// <returns></returns>
    public GameObject DeviceSink(GameObject go)
    {
        return m_DeviceSink.ReceivingItems(go);
    }

    /// <summary>
    /// この関数では氷プレートを取る事ができます。ない場合nullを返します。
    /// <para>関数()</para>
    /// <para>戻り値(GameObject)、容器にあるオブジェクトを渡す、なければnull</para>
    /// </summary>
    /// <returns></returns>
    public GameObject KeyPlateHole()
    {
       return m_KeyPlateHole.Take();
    }

    /// <summary>
    /// この関数では氷プレートを取る事ができます。ない場合nullを返します。
    /// <para>関数()</para>
    /// <para>戻り値(GameObject)、容器にあるオブジェクトを渡す、なければnull</para>
    /// </summary>
    /// <returns></returns>
    public GameObject KeyObjectPlateHole()
    {
        return m_KeyObjectPlateHole.Take();
    }

    /// <summary>
    /// この関数では冷凍庫にオブジェクトを入れることが出来ます。既にある場合交換します。
    /// <para>関数(入れるオブジェクト(GameObject))</para>
    /// <para>戻り値(GameObject)、冷凍庫にあるオブジェクトを渡す、なければnull</para>
    /// </summary>
    /// <returns></returns>
    public GameObject Freezer_1(GameObject go)
    {
      return m_Freezer_1.Arrangement(go);
    }

    /// <summary>
    /// この関数では冷凍庫からオブジェクトを取り出すことが出来ます。なければnullを返す。
    /// <para>関数()</para>
    /// <para>戻り値(GameObject)、冷凍庫にあるオブジェクトを渡す、なければnull</para>
    /// <para>引数にGameObjectを追加すると冷凍庫にオブジェクトを入れることができます。</para>
    /// </summary>
    /// <returns></returns>
    public GameObject Freezer_1()
    {
        return m_Freezer_1.Take();
    }

    /// <summary>
    /// この関数では冷凍庫を開け閉め出来ます。
    /// <para>関数()</para>
    /// <para>戻り値無し</para>
    /// <para>引数にboolを追加すると冷凍庫の開け閉めを指定できます。</para>
    /// </summary>
    /// <returns></returns>
    public void Freezer_1OpenOrClose()
    {
        m_Freezer_1.OpenOrClose();
    }

    /// <summary>
    /// この関数では冷凍庫を開け閉め出来ます。
    /// <para>関数(開け閉め(bool))</para>
    /// <para>戻り値無し</para>
    /// </summary>
    /// <param name="b">ture開ける。false閉める。</param>
    public void Freezer_1OpenOrClose(bool b)
    {
        m_Freezer_1.OpenOrClose(b);
    }

    /// <summary>
    /// この関数では冷凍庫にオブジェクトを入れることが出来ます。既にある場合交換します。
    /// <para>関数(入れるオブジェクト(GameObject))</para>
    /// <para>戻り値(GameObject)、冷凍庫にあるオブジェクトを渡す、なければnull</para>
    /// </summary>
    /// <returns></returns>
    public GameObject Freezer_2(GameObject go)
    {
        return m_Freezer_2.Arrangement(go);
    }

    /// <summary>
    /// この関数では冷凍庫からオブジェクトを取り出すことが出来ます。なければnullを返す。
    /// <para>関数()</para>
    /// <para>戻り値(GameObject)、冷凍庫にあるオブジェクトを渡す、なければnull</para>
    /// <para>引数にGameObjectを追加すると冷凍庫にオブジェクトを入れることができます。</para>
    /// </summary>
    /// <returns></returns>
    public GameObject Freezer_2()
    {
        return m_Freezer_2.Take();
    }

    /// <summary>
    /// この関数では冷凍庫を開け閉め出来ます。
    /// <para>関数()</para>
    /// <para>戻り値無し</para>
    /// <para>引数にboolを追加すると冷凍庫の開け閉めを指定できます。</para>
    /// </summary>
    /// <returns></returns>
    public void Freezer_2OpenOrClose()
    {
        m_Freezer_2.OpenOrClose();
    }

    /// <summary>
    /// この関数では冷凍庫を開け閉め出来ます。
    /// <para>関数(開け閉め(bool))</para>
    /// <para>戻り値無し</para>
    /// </summary>
    /// <param name="b">ture開ける。false閉める。</param>
    public void Freezer_2OpenOrClose(bool b)
    {
        m_Freezer_2.OpenOrClose(b);
    }

}
