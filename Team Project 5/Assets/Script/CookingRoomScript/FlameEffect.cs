using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameEffect : MonoBehaviour
{
    /// <summary>炎のエフェクト</summary>
    [SerializeField] GameObject FlameEffectObject;
    /// <summary>炎のエフェクト表示非表示</summary>
    public bool EffectSwitch { get; set; } = true;

    private void FixedUpdate()
    {
            FlameEffectObject.SetActive(EffectSwitch);
    }

}
