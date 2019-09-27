using System.Collections.Generic;
using Models;
using Views;

namespace Presenters
{
    public class GamePresenter
    {
        private readonly IGameView _gameView;
        private readonly GameModel _gameModel;

        public GamePresenter(IGameView gameView)
        {
            _gameView = gameView;
            _gameModel = new GameModel();
        }

        public void Open(int x, int y)
        {
            // すでにそのセル画空いてたらスキップする
            var cell = _gameModel.GetCells()[x, y];
            if (cell.IsOpened)
            {
                return;
            }

            if (_gameModel.IsGameOver)
            {
                return;
            }

            _gameModel.Open(x, y);
            if (_gameModel.IsGameOver)
            {
                var wonPlayer = _gameModel.GetCurrentCharacter() is Player;
                _gameView.GameOver(wonPlayer);
            }

            _gameView.UpdateCellColor(x, y, cell.GetColor());
        }

        public void ResetCells()
        {
            _gameModel.SetCurrentCharacter(_gameModel.Player);
            _gameModel.ResetCells();

            // ViewModelを作成
            var cellViewModels = new List<CellViewModel>();
            foreach (var cellModel in _gameModel.GetCells())
            {
                cellViewModels.Add(new CellViewModel(cellModel.X, cellModel.Y));
            }

            _gameView.ClearCells(cellViewModels.ToArray());
            _gameView.WriteToBoardEmpty();
        }
    }
}
