using UnityEngine;
using System.Collections;
using UnityEngine.UI;//この宣言が必要

public class textcontroller : MonoBehaviour
{

    [SerializeField] Text myText;
    [SerializeField] GameObject Panel;
    [SerializeField] Text bookText1;
    [SerializeField] Text bookText2;
    [SerializeField] GameObject bookPanel;


    int on = 0;
    bool on2 = true;
    bool on3 = true;
    bool on4 = true;

    // Use this for initialization
    void Start()
    {
        //myText = GetComponentInChildren<Text>();//UIのテキストの取得の仕方
        myText.text = "代替テキストC";//テキストの変更
    }

    // Update is called once per frame
    void Update()
    {
        switch (on)
        {
            /*case 0:
                Panel.SetActive(false);
                bookPanel.SetActive(false);
                break;
                */
            case 1:
                Panel.SetActive(true);
                bookPanel.SetActive(false);
                myText.text = "さてはクリックしたな？";
                break;
            case 2:
                Panel.SetActive(true);
                bookPanel.SetActive(false);
                myText.text = "ジャンプしたかった？";
                break;
            case 3:
                Panel.SetActive(false);
                bookPanel.SetActive(true);
                bookText1.text = "なんか書いてあると思った？";
                bookText2.text = "残念。特に何も書いてないよ。";
                break;
            default:
                Panel.SetActive(false);
                bookPanel.SetActive(false);
                break;
        }

        /*if (on)
        {
            Panel.SetActive(true);
            myText.text = "さてはクリックしたな？";
            on2 = true;
        }
        else if (on3)
        {
            Panel.SetActive(true);
            myText.text = "ジャンプしたかった？";
            on4 = true;
        }
        else
        {
            Panel.SetActive(false);
        }*/

        if (Input.GetButtonDown("Fire1"))
        {
            if (on2)
            {
                on = 1;
                on2 = false;
                on3 = false;
                on4 = false;
            }
            else
            {
                on = 0;
                on2 = true;
                on3 = true;
                on4 = true;
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (on3)
            {
                on = 3;
                on2 = false;
                on3 = false;
                on4 = false;
            }
            else
            {
                on = 0;
                on2 = true;
                on3 = true;
                on4 = true;
            }
        }

        if (Input.GetKeyDown("space"))
        {
            if (on4)
            {
                on = 2;
                on2 = false;
                on3 = false;
                on4 = false;
            }
            else
            {
                on = 0;
                on2 = true;
                on3 = true;
                on4 = true;
            }
        }
    }
}
