using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cleartext : MonoBehaviour
{
    Image BGimage;
    int i = 0;
    [SerializeField] Text myText;
    //[SerializeField] Text myText2;
    //[SerializeField] Text myText3;
    [SerializeField] GameObject Panel;
    [SerializeField] float desire = 0;
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
        BGimage =  this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (i < 130)
        {    
            Invoke("Tenmetsu", desire);
            i++;
            desire += 0.1f;
        }
        else
        {
            Panel.SetActive(true);
            myText.text = "congratulation!!";
            //myText2.text = "だが僕たちの脱出はこれからだ！";
            //myText3.text = "続きは製品版で！";
        }
    }

    void Tenmetsu()
    {
        Debug.Log(BGimage.color);
        BGimage.color += new Color(0f, 0f, 0f, 0.05f);
    }
}
