using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//この宣言が必要


public class hintsystemVersionC : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] Text hintText;
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject itemBar;
    public int Branch = 0;
    public int item = 0;
    public bool keyFlag = false;
    ItemBar itemScript;
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
        itemScript = itemBar.GetComponent<ItemBar>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void hint()
    {
        int i = 0;
        itemScript.ItemList();
        int a = 0;
        item = 0;
        //var a = itemScript.allItemList.Length;
        foreach (var item in itemScript.allItemList)
        {
            if (item != null)
            {
                a++;
            }
        }
        while (i < a) 
        {
            
                if (itemScript.allItemList[i].name == "IceKeyObjectPlate(Clone)")
            {
                if (item < 6)
                {
                    item = 6;
                }
            }
            if (itemScript.allItemList[i].name == "IceKeyPlate(Clone)")
            {
                if (item < 4)
                {
                    item = 4;
                }
            }
           
            if (!keyFlag)
            {
                if (itemScript.allItemList[i].name == "IceChangesFrom")
                {
                    if (itemScript.allItemList[i].transform.GetChild(0).name == "IceKeyObject")
                    {
                        if (item < 5)
                        {
                            item = 5;
                        }
                    }
                    if (itemScript.allItemList[i].transform.GetChild(0).name == "KeyObject")
                    {
                        keyFlag = true;
                        item = 3;
                    }
                    
                }
            }
            

            if (itemScript.allItemList[i].name == "KeyPlateHole")
            {
                if (item < 3)
                {
                    item = 3;
                }
            }
            if (itemScript.allItemList[i].name == "FlamePlate")
            {
                if (item < 2)
                {
                    item = 2;
                }
            }
            if (itemScript.allItemList[i].name == "KeyPlate")
            {
                if (item < 1)
                {
                    item = 1;
                }
            }
            
            i++;
        }
        
        switch (item)
        {
            case 0:
                hintText.text = "正面のシンクになんかプレートがあるな";
                break;

            case 1:
                hintText.text = "他にもシンクがあったな";
                break;

            case 2:
                hintText.text = "火のプレートを取ったらコンロの火がきえた？";
                break;

            case 5:
                hintText.text = "このオブジェクトの氷ってコンロの火で融かせないか？";
                break;

            case 3:
                hintText.text = "この型を使ってなんか作れそうだな";
                break;

            case 4:
                hintText.text = "似たようなような物があったな";
                break;

            case 6:
                hintText.text = "流石にここまでくれば何するかわかるな";
                break;

            default:
                hintText.text = "?????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????";
                break;
        }
        button.SetActive(false);
        Panel.SetActive(true);


    }

    public void HintClose()
    {
        Panel.SetActive(false);
        button.SetActive(true);
    }
}
