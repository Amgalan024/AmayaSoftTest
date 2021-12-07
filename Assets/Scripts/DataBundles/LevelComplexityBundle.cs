using UnityEngine;
[CreateAssetMenu(fileName = "New Level Complexity", menuName = "Level Complexity")]
public class LevelComplexityBundle : ScriptableObject
{
    [SerializeField] private Level[] levels;
    public Level[] Levels => levels;
}
