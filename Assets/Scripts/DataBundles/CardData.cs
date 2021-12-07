using System;
using UnityEngine;
[Serializable]
public class CardData
{
    [SerializeField] private string indetifier;
    [SerializeField] private Sprite sprite;
    public string Identifier => indetifier;
    public Sprite Sprite => sprite;
}
