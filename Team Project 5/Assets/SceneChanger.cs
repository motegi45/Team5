using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    Image BGimage;
    string currentSceneName;
    [SerializeField] Image plessKey;
    [SerializeField] Text keyp;
    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        BGimage =  this.GetComponent<Image>();

        //StartCoroutine(FadeIn());
        switch (currentSceneName)
        {
            case "Title":
                StartCoroutine(Tenmetsu());
                StartCoroutine(WaitSceneChange("Takizawa"));
                break;
            case "Takizawa":
                StartCoroutine(WaitSceneChange("Title"));
                break;
        }
        //StartCoroutine(WaitSceneChange());
    }



    IEnumerator WaitSceneChange(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(FadeOut(sceneName));
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine(FadeOut("Special"));
            }
            yield return null;
        }
    }

    IEnumerator FadeOut(string str)
    {
        if(keyp)
        {
            keyp.gameObject.SetActive(false);
        }
        while (BGimage.color.a < 1)
        {
            BGimage.color += new Color(0, 0, 0, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        if (BGimage.color.a >= 1f)
        {
            Debug.Log(BGimage.color.a);
            SceneManager.LoadScene(str);
        }
        
    }

    IEnumerator FadeIn()
    {
        while (BGimage.color.a > 0)
        {
            BGimage.color -= new Color(0, 0, 0, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator Tenmetsu()
    {
        while (true)
        {
            while (plessKey.color.a<1f)
            {
                plessKey.color += new Color(0, 0, 0, 0.1f);
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.3f);
            while (plessKey.color.a > 0)
            {
                plessKey.color -= new Color(0, 0, 0, 0.1f);
                yield return new WaitForSeconds(0.05f);
            }
            

        }
    }
}
