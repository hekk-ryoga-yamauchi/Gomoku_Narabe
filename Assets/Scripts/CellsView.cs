using System.Collections.Generic;
using UnityEngine;

public class CellsView : MonoBehaviour
{
    public void UpdateView() //modelのCellsをviewのCellsに反映させる
    {
        var cells = GetComponentsInChildren<CellView>();
        List<CellModel> cellsList = new List<CellModel>();
        foreach (var cell in GameModel.Instance.Cells)
        {
            cellsList.Add(cell);
        }
        var cellModels = cellsList.ToArray(); //1次元配列化したmodelのCells
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i].Cell = cellModels[i];
        }
    }
}
