using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class suuzi : MonoBehaviour
{
    [SerializeField] Text Text;
    [SerializeField] GameObject Panel;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void count()
    {
        i++;
        if (i >=10)
        {
            i = 0;
        }
        switch (i)
        {
            case 0:
                Text.text = "0";
                break;

            case 1:
                Text.text = "1";
                break;
            case 2:
                Text.text = "2";
                break;
            case 3:
                Text.text = "3";
                break;
            case 4:
                Text.text = "4";
                break;
            case 5:
                Text.text = "5";
                break;
            case 6:
                Text.text = "6";
                break;
            case 7:
                Text.text = "7";
                break;
            case 8:
                Text.text = "8";
                break;
            case 9:
                Text.text = "9";
                break;

            default:
                Text.text = "?";
                break;
        }
    }
}
