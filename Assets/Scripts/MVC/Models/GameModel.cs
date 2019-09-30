using UnityEngine;

namespace MVC.Models
{
    public class GameModel //全modelを持つクラス
    {
        private static readonly int CellSize = 17; //constはdllに値が直接入る、static readonlyの方が更新される可能性がある場合良い。
        private static readonly int LineUpCount = 5;
        private ICharactor _currentCharacter;
        private CellModel[,] _cells = new CellModel[CellSize, CellSize];
        public static GameModel Instance { get; } = new GameModel(); //シングルトン
        public Player Player = new Player();
        public Enemy Enemy = new Enemy();

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
                    var cell = new CellModel(j, i);
                    _cells[j, i] = cell;
                    cnt++;
                }
            }
        }

        public bool Open(int x, int y)
        {
            if (OutOfRange(x, y))
            {
                Debug.LogError("範囲外のcellが入力されました");
                return false;
            }
            if (_cells[x, y].IsOpened)
            {
                Debug.Log("すでに開いているセルです");
                return false;
            }
            if (_isGameOver)
            {
                Debug.Log("GameOverです");
                return false;
            }
            _cells[x, y].Character = _currentCharacter;
            _cells[x, y].IsOpened = true;
            if (CheckGameOver(x,y))
            {
                SetGameOver(true);
            }
            else
            {
                ChangeTurn();
            }
            return true;
        }

        public bool CheckGameOver(int x, int y)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        break;
                    }
                    if (CheckLine(x, y, i, j, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckLine(int x, int y, int dx, int dy, int cnt)
        {
            if (cnt >= LineUpCount - 1)
            {
                Debug.Log("ライン：" + cnt);
                return true;
            }

            if (OutOfRange(x + dx, y + dy))
            {
                return false;
            }

            if (_cells[x + dx, y + dy].IsOpened)
            {
                if (_cells[x + dx, y + dy].Character != _cells[x, y].Character)
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
            if (x < 0 || x >= CellSize || y < 0 || y >= CellSize)
            {
                return true;
            }
            return false;
        }

        private void SetGameOver(bool isGameOver)
        {
            _isGameOver = isGameOver;
        }

        public void ChangeTurn()
        {
            if (_currentCharacter is Player)
            {
                _currentCharacter = Enemy;
            }
            else
            {
                _currentCharacter = Player;
            }
        }
        public void SetCurrentCharacter(ICharactor character)
        {
            _currentCharacter = character;
        }

        public CellModel[,] GetCells()
        {
            return _cells;
        }

        public int GetCellSize()
        {
            return CellSize;
        }
    }
}