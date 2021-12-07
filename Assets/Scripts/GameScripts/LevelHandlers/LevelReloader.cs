using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
public class LevelReloader : MonoBehaviour
{
    [SerializeField] private LevelInitializer levelInitializer;
    [SerializeField] private UnityEvent onReloadLevelButtonPressed;
    [SerializeField] private Transform gameEndedScreen;
    [SerializeField] private Image backgroundImage;
    public void AddListener(LevelSwitcher levelSwitcher)
    {
        onReloadLevelButtonPressed.AddListener(delegate { StartCoroutine(ReloadLevel(levelSwitcher)); });
    }
    public void ButtonReloadLevelClick()
    {
        onReloadLevelButtonPressed?.Invoke();
    }
    public IEnumerator ReloadLevel(LevelSwitcher levelSwitcher)
    {
        levelInitializer.ClearCardPanel();
        levelSwitcher.LoadStartLevel();
        yield return StartCoroutine(CloseGameEndedScreen());
    }
    public IEnumerator OpenGameEndedScreen()
    {
        gameEndedScreen.gameObject.SetActive(true);
        var animSequence = DOTween.Sequence();
        animSequence.Append(backgroundImage.DOFade(1f, 1f));
        yield return new WaitWhile(animSequence.IsPlaying);
    }
    public IEnumerator CloseGameEndedScreen()
    {
        var animSequence = DOTween.Sequence();
        animSequence.Append(backgroundImage.DOFade(0f, 1f));
        yield return new WaitWhile(animSequence.IsPlaying);
        gameEndedScreen.gameObject.SetActive(false);
    }
}
