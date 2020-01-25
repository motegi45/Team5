using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class opensystem : MonoBehaviour
{
    [SerializeField] GameObject door;
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = door.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        anim.Play();
    }
}
