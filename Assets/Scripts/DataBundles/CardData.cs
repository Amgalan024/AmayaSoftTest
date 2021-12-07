using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[Serializable]
public class CardData
{
    [SerializeField] private string indetifier;
    [SerializeField] private Sprite sprite;
    public string Identifier => indetifier;
    public Sprite Sprite => sprite;
}
