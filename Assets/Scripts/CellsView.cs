using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellsView : MonoBehaviour
{
   public static int CellSize = 17;
   public static CellModel[,] Cells = new CellModel[CellSize,CellSize];
   private void Start()
   {
      SetCells();
   }

   public void SetCells()
   {
      var cells = GetComponentsInChildren<CellView>();
      int cnt = 0;
      for (var i = 0; i < CellSize; i++)
      {
         for (var j = 0; j < CellSize; j++)
         {
            var cell = new CellModel(j,i);
            Cells[j, i] = cell;
            cells[cnt].Cell = cell;
            cnt++;
         }
      }
   }
}
