using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class blackOut : MonoBehaviour
{
    Image BGimage;
    int i = 0;
    //[SerializeField] Text myText;
    //[SerializeField] Text myText2;
    //[SerializeField] Text myText3;
    [SerializeField] GameObject Panel;
    [SerializeField] float desire = 0;
    [SerializeField] string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
        BGimage = this.GetComponent<Image>();
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
            SceneManager.LoadScene(sceneName);
        }
    }
    void Tenmetsu()
    {
        Debug.Log(BGimage.color);
        BGimage.color += new Color(0f, 0f, 0f, 0.05f);
    }
}
