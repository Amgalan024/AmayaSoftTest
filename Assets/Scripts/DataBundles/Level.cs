using System;
using UnityEngine;
[Serializable]
public class Level
{
    [SerializeField] private int rowCount;
    [SerializeField] private int columnCount;
    public int RowCount => rowCount;
    public int ColumnCount => columnCount;
    public int ElementsCount => RowCount * ColumnCount;
}
