using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageWait : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("DeleteMs", 1f);
    }

    public void DeleteMs()
    {
        this.gameObject.SetActive(false);
    }
}
