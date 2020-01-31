using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Diyal : MonoBehaviour
{

    [SerializeField] Button[] keyButtons;
    [SerializeField] GameObject[] buttonBlock;
    [SerializeField] Text result;
    [SerializeField] GameObject[] buttonHekomu;
    int blockIndex;
    [SerializeField] float m_moveTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void numberButtonClick(int block)
    {
        SmoothMove(buttonHekomu[block].transform);
        result.text  += block.ToString();
        SmoothMove(buttonBlock[block].transform);
    }
    public void deleteButtonClick(int block)
    {
        SmoothMove(buttonHekomu[block].transform);
        result.text = "";
        SmoothMove(buttonBlock[block].transform);
    }
    public void enterButtonClick(int block)
    {
        SmoothMove(buttonHekomu[block].transform);
        if (result.text == "0000")
        {

        }
        SmoothMove(buttonBlock[block].transform);
    }
    public void SmoothMove(Transform target)
    {
        transform.DOLocalMove(target.transform.position, m_moveTime);
        transform.DORotateQuaternion(target.transform.rotation, m_moveTime);
    }
}
