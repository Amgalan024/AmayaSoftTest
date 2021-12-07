using UnityEngine;
[CreateAssetMenu(fileName = "New Data Bundle", menuName = "Data Bundles")]
public class CardDataBundle : ScriptableObject
{
    [SerializeField] private CardData[] cards;
    public CardData[] Cards => cards;
}
