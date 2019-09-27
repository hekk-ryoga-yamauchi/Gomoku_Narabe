using UnityEngine;

namespace Models
{
    public class GameModel //全modelを持つクラス
    {
        public static readonly int CellSize = 17; //constはdllに値が直接入る、static readonlyの方が更新される可能性がある場合良い。
        private static readonly int LineUpCount = 5;
        private ICharactor _currentCharacter;
        private  CellModel[,] _cells = new CellModel[CellSize,CellSize];
        public  Player Player = new Player();
        public  Enemy Enemy = new Enemy();
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

        public void Open(int x, int y)
        {
            _cells[x, y].Character = _currentCharacter;
            _cells[x,y].IsOpened = true;

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
            foreach (var cell in _cells)
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
            if (_cells[x + dx,y + dy].IsOpened)
            {
                if(_cells[x+dx,y+dy].Character != _cells[x,y].Character)
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
            if (_currentCharacter is Player)
            {
                _currentCharacter = Enemy;
            }
            else
            {
                _currentCharacter = Player;
            }
        }

        public ICharactor GetCurrentCharacter()
        {
            return _currentCharacter;
        }

        public void SetCurrentCharacter(ICharactor character)
        {
            _currentCharacter = character;
        }

        public CellModel[,] GetCells()
        {
            return _cells;
        }

        public CellModel GetCell(int x, int y)
        {
            return _cells[y, x];
        }
    }
}
