using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;
using System;
public class SpriteList : MonoBehaviour
{
    public List<Sprite> avatars;

    public Sprite selectedSprite;

    public void initialize() {
        avatars = new List<Sprite>();
    }

    public void SelectSprite(Sprite sprite) {
        selectedSprite = sprite;
    }
}