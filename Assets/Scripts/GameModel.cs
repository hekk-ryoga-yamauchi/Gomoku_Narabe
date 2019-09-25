using System.Collections.Generic;
using UnityEngine;

public class GameModel //全modelを持つクラス
{
    public const int CellSize = 17;
    public const int LineUpCount = 5;
    public int CurrentTurnCharaId;

    public static GameModel Instance { get; } = new GameModel(); //シングルトン
    public static Player Player { get; } = new Player(); //シングルトン
    public static Enemy Enemy { get; } = new Enemy(); //シングルトン
    public CellModel[,] Cells = new CellModel[CellSize,CellSize];
    public bool IsGameOver
    {
        get { return _isGameOver; }
    }
    private bool _isGameOver { get; set; }

    public void ResetCells()
    {
        _isGameOver = false;
        int cnt = 0;
        for (var i = 0; i < CellSize; i++)
        {
            for (var j = 0; j < CellSize; j++)
            {
                var cell = new CellModel(j,i);
                Cells[j, i] = cell;
                cnt++;
            }
        }
    }

    public void Open(int x, int y)
    {
        Cells[x,y].CharaId = CurrentTurnCharaId;
        Cells[x,y].IsOpened = true;
        
        if (CheckGameOver())
        {
            SetGameOver(true);
        }
        else
        {
            ChangeTurn();
        }
    }
    public bool CheckGameOver()
    {
        foreach (var cell in Cells)
        {
            if (cell.IsOpened)
            {
                if (CheckLine(cell.X, cell.Y, 0, 1, 0))
                {
                    return true;
                }
                if (CheckLine(cell.X, cell.Y, 1, 1, 0))
                {
                    return true;
                }
                if (CheckLine(cell.X, cell.Y, 1, 0, 0))
                {
                    return true;
                }
                if (CheckLine(cell.X, cell.Y, 1, -1, 0))
                {
                    return true;
                }
            }
        }
        return false;
    }
    private bool CheckLine(int x, int y, int dx, int dy, int cnt)
    {
        if (cnt >= LineUpCount-1)
        {
            Debug.Log("ライン：" + cnt);
            return true;
        }

        if (OutOfRange(x + dx, y + dy))
        {
            return false;
        }
        if (Cells[x + dx,y + dy].IsOpened)
        {
            if (Cells[x + dx, y + dy].CharaId != Cells[x, y].CharaId)
            {
                return false;
            }
            cnt++;
            if (CheckLine(x + dx, y + dy, dx, dy, cnt))
            {
                return true;
            }
            
        }

        return false;
    }
    private bool OutOfRange(int x, int y)
    {
        if (x < 0 || x >= CellSize || y < 0 || y >= CellSize) return true;
        return false;
    }

    private void SetGameOver(bool isGameOver)
    {
        _isGameOver = isGameOver;
    }
    public void ChangeTurn()
    {
        if (CurrentTurnCharaId == 0)
        {
            CurrentTurnCharaId = 1;
        }
        else
        {
            CurrentTurnCharaId = 0;
        }
    }
}
