using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpriteSetter : MonoBehaviour
{
    public Sprite[] sprites;
    public Image Image;

    private void OnEnable()
    {
        Image.sprite = sprites[Random.Range(0, sprites.Length - 1)];
    }

}
