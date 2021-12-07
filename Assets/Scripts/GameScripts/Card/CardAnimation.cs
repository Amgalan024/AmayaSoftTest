using System.Linq;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CardAnimation : MonoBehaviour
{
    public IEnumerator PlayBounceInAnimation(Card card)
    {
        var animSequence = DOTween.Sequence();
        animSequence.Append(card.transform.DOScale(0, 1f).SetEase(Ease.InBounce));
        yield return new WaitWhile(animSequence.IsPlaying);
    }
    public IEnumerator PlayBounceOutAnimation(Card card)
    {
        card.transform.localScale = new Vector3(0,0);
        var animSequence = DOTween.Sequence();
        animSequence.Append(card.transform.DOScale(1, 1f).SetEase(Ease.OutBounce));
        yield return new WaitWhile(animSequence.IsPlaying);
    }
    public IEnumerator PlayRightAnswerAnimation(Card card)
    {
        card.StarParticles.Play();
        yield return StartCoroutine(PlayBounceInAnimation(card));
    }
    public IEnumerator PlayWrongAnswerAnimation(Card card)
    {
        var animSequence = DOTween.Sequence();
        animSequence.Append(card.Image.gameObject.transform.DOShakePosition(1f, 3, 10));
        yield return new WaitWhile(animSequence.IsPlaying);
    }
}
