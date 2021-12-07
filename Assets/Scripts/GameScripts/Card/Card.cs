using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Card : MonoBehaviour
{
    [SerializeField] private UnityEvent onCardTapped;
    [SerializeField] private Image image;
    [SerializeField] private ParticleSystem starParticles;
    public ParticleSystem StarParticles => starParticles;
    public CardData Data { private set; get; }
    public Image Image => image;
    public void InitializeCard(CardData cardData)
    {
        this.Data = cardData;
        image.sprite = cardData.Sprite;
    }
    public void CardTap()
    {
        onCardTapped?.Invoke();
    }
    public void AddListener(AnswerHandler answerHandler)
    {
        onCardTapped.AddListener(delegate { answerHandler.CheckAnswer(Data.Identifier, this); });
    }
}
