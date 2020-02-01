using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//この宣言が必要

public class hintsystem : MonoBehaviour
{
    [SerializeField] GameObject buttonPanel;
    [SerializeField] Text hintText;
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject itemBar;
    public int Branch = 0;
    public int item = 0;
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
        

        while (i < 8)
        {

            if (itemScript.allItemList[i].name == "HintPlane" || itemScript.allItemList[i].name == "HintPlane2")
            {
                item++;
            }
            i++;
        }
        switch (item)
        {
            case 0:
                hintText.text = "とりあえず色々見てみよう";
                break;

            case 1:
                hintText.text = "まだヒントがありそうだな";
                break;

            case 2:
                switch (Branch)
                {
                    case 0:
                        hintText.text = "そういえばビリヤード台があったな";
                        break;
                    case 1:
                        hintText.text = "ビリヤード台は2つあったな";
                        break;
                    case 2:
                        hintText.text = "なんか色が似てる？";
                        break;
                    default:
                        hintText.text = "????????????????????????????????????????????????????????????????????????????????????????";
                        break;
                }
               
                break;
            default:
                hintText.text = "????????????????????????????????????????????????????????????????????????????????????????";
                break;
        }
        buttonPanel.SetActive(false);
        Panel.SetActive(true);
        
        
    }

    public void HintClose()
    {
        Panel.SetActive(false);
        buttonPanel.SetActive(true);
    }
}
