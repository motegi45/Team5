using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSystem : MonoBehaviour
{
    [SerializeField] GameObject diary1;
    [SerializeField] GameObject penLight1;
    [SerializeField] GameObject key1;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneSaverCh.key)
        {
            Destroy(key1);
        }
        if (SceneSaverCh.penLight)
        {
            Destroy(penLight1);
        }
        if (SceneSaverCh.diary)
        {
            Destroy(diary1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}


