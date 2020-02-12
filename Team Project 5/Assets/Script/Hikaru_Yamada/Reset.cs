using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneSaverCh.diary = false;
        SceneSaverCh.penLight = false;
        SceneSaverCh.key = false;
        SceneSaverCh.doa = false;
        SceneSaverCh.cookingCrea = false;
        SceneSaverCh.enterCrea = false;
        SceneSaverCh.stoneOn1 = false;
        SceneSaverCh.stoneOn2 = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
