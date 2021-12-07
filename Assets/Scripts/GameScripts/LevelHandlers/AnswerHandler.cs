using UnityEngine;
using UnityEngine.Events;

public class AnswerHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent onAnsweredCorrectly;
    [SerializeField] private UnityEvent onAnsweredIncorrectly;
    [SerializeField] private CardAnimation cardAnimation;
    public string AnswerIndentifier { set; get; }
    private Card currentCardTapped;
    public void AddListener(LevelSwitcher levelSwitcher)
    {
        onAnsweredCorrectly.AddListener(delegate { StartCoroutine(levelSwitcher.LoadNextLevel(currentCardTapped)); });
        onAnsweredIncorrectly.AddListener(delegate { StartCoroutine(cardAnimation.PlayWrongAnswerAnimation(currentCardTapped)); });
    }
    public void CheckAnswer(string cellIdentifier, Card card)
    {
        currentCardTapped = card;
        if (cellIdentifier == AnswerIndentifier)
        {
            onAnsweredCorrectly?.Invoke();
        }
        else
        {
            onAnsweredIncorrectly?.Invoke();
        }
    }

}
