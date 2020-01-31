using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//この宣言が必要
using DG.Tweening;

public class titlecontroller : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [SerializeField] Text text;
    Image image;
    Image textImage;

    // Start is called before the first frame update
    void Start()
    {
        image = Panel.gameObject.GetComponent<Image>();
        textImage = text.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        DOTween.ToAlpha(
            () => textImage.color,
            color => textImage.color = color,
            0f,                                // 最終的なalpha値
            3f
        );
    }
    public void Title()
    {
        DOTween.ToAlpha(
            () => image.color,
            color => image.color = color,
            255f,                             // 最終的なalpha値
            5f
        );
    }
}
