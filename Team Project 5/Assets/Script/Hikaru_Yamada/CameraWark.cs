﻿using System.Collections;
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


    //special
    public bool backMode = false;
    [SerializeField] public float backY;
    [SerializeField] public float backX;
    [SerializeField] public float backZ;
    public Vector3 savePosition;
    public Quaternion  saveRotation;

    // Start is called before the first frame update
    void Start()
    {
        savePosition = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnRight()
    {
        cameraTransform.position = savePosition;
        y = 90;
        cameraTransform.Rotate(new Vector3(x,y,z));
        x = 0;
        y = 0;
        z = 0;
        //ここから
        saveRotation = cameraTransform.rotation;
        if (backMode)
        {
            if (saveRotation.w == saveRotation.y)
            {
                cameraTransform.position = new Vector3(savePosition.x - backX, savePosition.y, savePosition.z);
            }
            else if (saveRotation.w == 0)
            {
                cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z + backZ);
            }
            else if (saveRotation.w == -saveRotation.y || -saveRotation.w == saveRotation.y)
            {
                cameraTransform.position = new Vector3(savePosition.x + backX, savePosition.y, savePosition.z);
            }
            else if (saveRotation.w == -1 || saveRotation.w == 1)
            {
                cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z - backZ);
            }
        }

    }

    public void TurnLeft()
    {
        cameraTransform.position = savePosition;
        y = -90;
        cameraTransform.Rotate(new Vector3(x, y, z));
        x = 0;
        y = 0;
        z = 0;
        //ここから
        saveRotation = cameraTransform.rotation;
        if (backMode)
        {
            if (saveRotation.w == saveRotation.y)
            {
                cameraTransform.position = new Vector3(savePosition.x - backX, savePosition.y, savePosition.z);
            }
            else if (saveRotation.w == 0)
            {
                cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z + backZ);
            }
            else if (saveRotation.w == -saveRotation.y || -saveRotation.w == saveRotation.y)
            {
                cameraTransform.position = new Vector3(savePosition.x + backX, savePosition.y, savePosition.z);
            }
            else if (saveRotation.w == -1 || saveRotation.w == 1)
            {
                cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z - backZ);
            }
        }
    }

    public void TurnUp()
    {
        cameraTransform.position = savePosition;
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
            if (backMode)
            {
                cameraTransform.position = new Vector3(savePosition.x, savePosition.y - backY, savePosition.z);
            }
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
            saveRotation = cameraTransform.rotation;
            if (backMode)
            {
                if (saveRotation.w == saveRotation.y)
                {
                    cameraTransform.position = new Vector3(savePosition.x - backX, savePosition.y, savePosition.z);
                }
                else if (saveRotation.w == 0)
                {
                    cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z + backZ);
                }
                else if (saveRotation.w == -saveRotation.y || -saveRotation.w == saveRotation.y)
                {
                    cameraTransform.position = new Vector3(savePosition.x + backX, savePosition.y, savePosition.z);
                }
                else if (saveRotation.w == -1 || saveRotation.w == 1)
                {
                    cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z - backZ);
                }
            }
        }
        

    }

    public void TurnDown()
    {
        cameraTransform.position = savePosition;
        if (!flagDown&&!flagUp)
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
            if (backMode)
            {
                cameraTransform.position = new Vector3(savePosition.x, savePosition.y + backY, savePosition.z);
            }
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
            saveRotation = cameraTransform.rotation;
            if (backMode)
            {
                if (saveRotation.w == saveRotation.y)
                {
                    cameraTransform.position = new Vector3(savePosition.x - backX, savePosition.y, savePosition.z);
                }
                else if (saveRotation.w == 0)
                {
                    cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z + backZ);
                }
                else if (saveRotation.w == -saveRotation.y || -saveRotation.w == saveRotation.y)
                {
                    cameraTransform.position = new Vector3(savePosition.x + backX, savePosition.y, savePosition.z);
                }
                else if (saveRotation.w == -1 || saveRotation.w == 1)
                {
                    cameraTransform.position = new Vector3(savePosition.x, savePosition.y, savePosition.z - backZ);
                }
            }
        }
        


    }


}
