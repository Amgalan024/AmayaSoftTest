using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private LevelInitializer levelInitializer;
    [SerializeField] private LevelReloader levelReloader;
    [SerializeField] private LevelComplexityBundle levelBundle;
    [SerializeField] private CardAnimation cardAnimation;
    [SerializeField] private AnswerHandler answerHandler;
    private int levelIndex = 0;
    private int maxLevelIndex;
    private void Start()
    {
        LoadStartLevel();
        answerHandler.AddListener(this);
        levelReloader.AddListener(this);
    }
    public void LoadStartLevel()
    {
        levelIndex = 0;
        maxLevelIndex = levelBundle.Levels.Length - 1;
        levelInitializer.InitializeLevel(levelBundle.Levels[levelIndex], this, answerHandler);
        foreach (var card in levelInitializer.PanelCardsArray)
        {
            StartCoroutine(cardAnimation.PlayBounceOutAnimation(card));
        }
    }
    public IEnumerator LoadNextLevel(Card currentCardTapped)
    {
        yield return StartCoroutine(cardAnimation.PlayRightAnswerAnimation(currentCardTapped));
        if (levelIndex < maxLevelIndex)
        {
            levelIndex++;
            levelInitializer.ClearCardPanel();
            levelInitializer.InitializeLevel(levelBundle.Levels[levelIndex], this, answerHandler);
        }
        else
        {
            StartCoroutine(levelReloader.OpenGameEndedScreen());
        }
    }
  
}


