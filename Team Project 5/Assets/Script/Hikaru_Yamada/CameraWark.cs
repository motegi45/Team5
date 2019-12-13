using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class CameraWark : MonoBehaviour
{
    /// <summary></summary>
    [SerializeField] Transform cameraTransform;
    [SerializeField] GameObject left;
    [SerializeField] GameObject right;
    [SerializeField] GameObject up;
    [SerializeField] GameObject down;
    [SerializeField] GameObject down2;
    [SerializeField] GameObject gameManager;
    public float x = 0;
    public float y = 0;
    public float z = 0;
    public bool flagDown = false;
    public bool flagUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnRight()
    {
        y = 90;
        cameraTransform.Rotate(new Vector3(x,y,z));
        x = 0;
        y = 0;
        z = 0;
    }

    public void TurnLeft()
    {
        y = -90;
        cameraTransform.Rotate(new Vector3(x, y, z));
        x = 0;
        y = 0;
        z = 0;
    }

    public void TurnUp()
    {
        if (!flagUp&&!flagDown)
        {
            x = -90;
            cameraTransform.Rotate(new Vector3(x, y, z));
            x = 0;
            y = 0;
            z = 0;
            left.SetActive(false);
            right.SetActive(false);
            up.SetActive(false);
            flagUp = true;
        }
        else if(flagDown)
        {
            BarOpen openScript = gameManager.GetComponent<BarOpen>();
            x = -90;
            cameraTransform.Rotate(new Vector3(x, y, z));
            x = 0;
            y = 0;
            z = 0;
            left.SetActive(true);
            right.SetActive(true);
            if(openScript.flag)
            {
                down.SetActive(true);
            }
            else if (!openScript.flag)
            {
                down2.SetActive(true);
            }
            flagDown = false;
        }
        
    }

    public void TurnDown()
    {
        if(!flagDown&&!flagUp)
        {
            x = 90;
            cameraTransform.Rotate(new Vector3(x, y, z));
            x = 0;
            y = 0;
            z = 0;
            left.SetActive(false);
            right.SetActive(false);
            down.SetActive(false);
            down2.SetActive(false);
            flagDown = true;
        }
        else if(flagUp)
        {
            x = 90;
            cameraTransform.Rotate(new Vector3(x, y, z));
            x = 0;
            y = 0;
            z = 0;
            left.SetActive(true);
            right.SetActive(true);
            up.SetActive(true);
            flagUp = false;
        }
        


    }


}

