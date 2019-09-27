using System.Linq;
using UnityEngine;

namespace Views
{
    public class CellsView : MonoBehaviour
    {
        public CellView GetCellView(int x, int y)
        {
            var cellViews = GetComponentsInChildren<CellView>();
            return cellViews.FirstOrDefault(cell => cell.X == x && cell.Y == y);
        }

        public CellView[] GetCellViews()
        {
            var cellViews = GetComponentsInChildren<CellView>();
            return cellViews;
        }

        public void ResetCells(CellViewModel[] cellViewModels)
        {
            var cellViews = GetComponentsInChildren<CellView>();
            for (var i = 0; i < cellViews.Length; i++)
            {
                cellViews[i].ResetViewModel(cellViewModels[i]);
            }
        }
    }
}
