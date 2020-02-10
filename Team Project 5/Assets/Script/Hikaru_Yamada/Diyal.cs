using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Diyal : MonoBehaviour
{
    [SerializeField] GameObject Door;
    Animation Open;
    [SerializeField] Button[] keyButtons;
    [SerializeField] GameObject[] buttonBlock;
    [SerializeField] Text result;
    [SerializeField] GameObject[] buttonHekomu;
    int blockIndex;
    [SerializeField] float m_moveTime = 0.2f;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (Door)
        {
            Open = Door.GetComponent<Animation>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void numberButtonClick(int block)
    {
        if (count < 5)
        {
            count++;
            //SmoothMove(buttonHekomu[block].transform);
            result.text += block.ToString();
            //SmoothMove(buttonBlock[block].transform);
        }
    }
    public void deleteButtonClick(int block)
    {
        //SmoothMove(buttonHekomu[block].transform);
        result.text = "";
        //SmoothMove(buttonBlock[block].transform);
        count = 0;
    }
    public void enterButtonClick(int block)
    {
        //SmoothMove(buttonHekomu[block].transform);
        if (result.text == "1256")
        {
            Open.Play();
        }
        //SmoothMove(buttonBlock[block].transform);
    }
    public void SmoothMove(Transform target)
    {
        transform.DOLocalMove(target.transform.position, m_moveTime);
        transform.DORotateQuaternion(target.transform.rotation, m_moveTime);
    }
}
