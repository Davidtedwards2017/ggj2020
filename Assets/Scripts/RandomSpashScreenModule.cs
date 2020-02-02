using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpashScreenModule : SplashScreenModule
{
    public Sprite[] sprites;
    public Image Image;

    protected override void OnActivated()
    {
        SetImage();
        base.OnActivated();
    }

    void SetImage()
    {
        Image.sprite = sprites[Random.Range(0, sprites.Length - 1)];
    }
}
