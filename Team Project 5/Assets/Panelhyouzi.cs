using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panelhyouzi : MonoBehaviour
{
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
    public void Clear()
    {
        Panel.SetActive(true);
    }
}
