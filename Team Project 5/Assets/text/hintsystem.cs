using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//この宣言が必要

public class hintsystem : MonoBehaviour
{
    [SerializeField] Text buttonText;
    [SerializeField] Text hintText;
    [SerializeField] GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void hint()
    {
        Panel.SetActive(true);
        switch (0)
        {
            case 0:
                hintText.text = "なんもねーよ";
                break;

            default:
        }
    }
}
