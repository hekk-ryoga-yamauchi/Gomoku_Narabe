using DefaultNamespace;
using UnityEngine;

public class GameController
{
    public static GameController Instance  = new GameController();
    public static int LineUpCount = 5;
    public int CurrentTurnCharaId = 0;
    public CellModel[,] Cells => CellsView.Cells;
    public Player Player = new Player(); //0
    public Enemy Enemy  = new Enemy();   //1
    public bool OnGameOver = false;

    void Start()
    {
        Init();
        ChangeTurn();  // 初手は自分ターン;
    }
    
    private void Init()
    {
        Instance = new GameController();
    }
    public void CheckBoard()
    {
        foreach (var cell in Cells)
        {
            if (cell.IsOpened)
            {
                CheckLine(cell.X,cell.Y,0,1,0);
                CheckLine(cell.X,cell.Y,1,1,0);
                CheckLine(cell.X,cell.Y,1,0,0);
                CheckLine(cell.X,cell.Y,1,-1,0);
            }
        }
    }

    private void CheckLine(int x, int y, int dx, int dy, int cnt)
    {
        if (cnt >= LineUpCount-1)
        {
            Debug.Log("ライン：" + cnt);
            GameOver();
        }
        if (OutOfRange(x + dx, y + dy)) return;
        if (Cells[x + dx,y + dy].IsOpened)
        {
            if (Cells[x + dx, y + dy].CharaId != Cells[x,y].CharaId) return;
            cnt++;
            CheckLine(x+dx,y+dy,dx,dy,cnt);
        }
    }

    private bool OutOfRange(int x, int y)
    {
        if (x < 0 || x >= CellsView.CellSize || y < 0 || y >= CellsView.CellSize) return true;
        return false;
    }

    private void GameOver()
    {
        OnGameOver = true;
    }

    public void ChangeTurn()
    {
        if (CurrentTurnCharaId == 0)
        {
            CurrentTurnCharaId = 1;
            Enemy.StartTurn();
        }
        else
        {
            CurrentTurnCharaId = 0;
            Player.StartTurn();
        }
    }
}
