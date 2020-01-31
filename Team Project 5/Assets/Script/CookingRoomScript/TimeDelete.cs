using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelete : MonoBehaviour
{
    [SerializeField] float m_Time = 60f;
    private float count;

    private void FixedUpdate()
    {
        count += Time.deltaTime;

        if(count >= m_Time)
        {
            Destroy(gameObject);
        }
    }
}
