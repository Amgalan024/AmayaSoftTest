using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelInitializer : MonoBehaviour
{
    [SerializeField] private CardDataBundle[] cardBundles;
    [SerializeField] private Transform cardPanel;
    [SerializeField] private Card cardPrefab;
    [SerializeField] private Text taskText;
    public Card[] PanelCardsArray { private set; get; }
    private List<CardData> currentCardsDataList = new List<CardData>();
    private List<string> tasksIdentifiers = new List<string>();
    private GridLayoutGroup cardGridLayoutGroup;
    private void Awake()
    {
        cardGridLayoutGroup = cardPanel.GetComponent<GridLayoutGroup>();
    }
    public void InitializeLevel(Level levelComplexity, LevelSwitcher levelSwitcher, AnswerHandler answerHandler)
    {
        InitializeCellsPanel(levelComplexity, levelSwitcher, answerHandler);
        InitializeTask(answerHandler);
    }
    private void InitializeTask(AnswerHandler answerHandler)
    {
        int randomIndex = Random.Range(0, PanelCardsArray.Length);
        while (tasksIdentifiers.Contains(PanelCardsArray[randomIndex].Data.Identifier))
        {
            randomIndex = Random.Range(0, PanelCardsArray.Length);
        }
        answerHandler.AnswerIndentifier = PanelCardsArray[randomIndex].Data.Identifier;
        tasksIdentifiers.Add(PanelCardsArray[randomIndex].Data.Identifier);
        taskText.text = $"Find {answerHandler.AnswerIndentifier}";
    }
    private void InitializeCellsPanel(Level levelComplexity, LevelSwitcher levelSwither, AnswerHandler answerHandler)
    {
        int randomCardBundle = Random.Range(0, cardBundles.Length);
        currentCardsDataList = cardBundles[randomCardBundle].Cards.ToList<CardData>();
        PanelCardsArray = new Card[levelComplexity.ElementsCount];
        cardGridLayoutGroup.constraintCount = levelComplexity.ColumnCount;
        for (int i = 0; i < levelComplexity.ElementsCount; i++)
        {
            int randomIndex;
            randomIndex = Random.Range(0, currentCardsDataList.Count);
            PanelCardsArray[i] = Instantiate(cardPrefab, cardPanel);
            PanelCardsArray[i].InitializeCard(currentCardsDataList[randomIndex]);
            currentCardsDataList.RemoveAt(randomIndex);
            PanelCardsArray[i].AddListener(answerHandler);
        }
    }
    public void ClearCardPanel()
    {
        foreach (var card in PanelCardsArray)
        {
            Destroy(card.gameObject);
        }
    }

}
