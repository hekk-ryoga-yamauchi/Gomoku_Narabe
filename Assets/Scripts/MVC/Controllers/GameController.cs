using MVC.Models;
using MVC.Views;
using UnityEngine;

namespace MVC.Controllers
{
    public class GameController
    {
        private IGameView _gameView;
        private GameModel _gameModel;
        public int CellSize { get => _gameModel.GetCellSize(); }
        public GameController(IGameView gameView)
        {
            _gameView = gameView;
            _gameModel = new GameModel();
        }

    public void Open(int x, int y)
    {
        var Cells = GameModel.Instance.GetCells();
            if (GameModel.Instance.Open(x, y))
            {
                _gameView.SetCellColor(x, y, Cells[x, y].GetColor());
            }

            if (GameModel.Instance.IsGameOver)
            { 
                _gameView.WriteGameOverView("GameOver!!");
            }
        }

        public void ResetCells()
        {
            GameModel.Instance.SetCurrentCharacter(GameModel.Instance.Player);
            GameModel.Instance.ResetCells();
            for (var i = 0; i < GameModel.Instance.GetCellSize(); i++)
            {
                for (var j = 0; j < GameModel.Instance.GetCellSize(); j++)
                {
                    _gameView.SetCellColor(j, i, Color.white);
                }
            }
            _gameView.WriteGameOverView("");
        }
    }
}