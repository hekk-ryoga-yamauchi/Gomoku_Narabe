using MVC.Models;
using MVC.Views;
using UnityEngine;

namespace MVC.Controllers
{
    public class GameController
    {
        private IGameView _gameView;
        private GameModel _gameModel;
        private ICharacterModel _currentTurnCharacter => _gameModel.GetCurrentCharacterModel();

        public int CellSize
        {
            get => _gameModel.GetCellSize();
        }

        public GameController(IGameView gameView)
        {
            _gameView = gameView;
            _gameModel = new GameModel();
        }

        public void Open(int x, int y)
        {
            var Cells = _gameModel.GetCells();
            if (_gameModel.CanOpen(x, y))
            {
                _gameView.SetCellColor(x, y, GetCurrentTurnCharacterColor());
                _gameModel.Open(x, y);
            }

            if (_gameModel.IsGameOver)
            {
                _gameView.WriteGameOverView("GameOver!!");
            }

            StartTurn();
        }

        public void ResetCells()
        {
            _gameModel.SetCurrentCharacter(_gameModel.GetPlayer());
            _gameModel.ResetCells();
            for (var i = 0; i < _gameModel.GetCellSize(); i++)
            {
                for (var j = 0; j < _gameModel.GetCellSize(); j++)
                {
                    _gameView.SetCellColor(j, i, Color.white);
                }
            }

            _gameView.WriteGameOverView("");
        }

        public void StartTurn()
        {
            var text = _currentTurnCharacter.StartTurn();
            _gameView.StartTurn(text);
        }

        public Color GetCurrentTurnCharacterColor()
        {
            return _currentTurnCharacter.Color;
        }
    }
}