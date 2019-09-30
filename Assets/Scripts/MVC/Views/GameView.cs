using System;
using MVC.Controllers;
using UnityEngine;

namespace MVC.Views
{
    public interface IGameView : IView
    {
        void SetCellColor(int x, int y, Color color);
        void WriteGameOverView(string text);
    }
    public class GameView : MonoBehaviour, IGameView
    {
        [SerializeField] private GameOverView _gameOverView = default;
        [SerializeField] private GameController _gameController;
        [SerializeField] private CellView[,] CellViews;
        [SerializeField] private ResetButtonView _resetButtonView;

        private void Awake()
        {
            _gameController = new GameController(this);
            if (_resetButtonView == null) _resetButtonView = GetComponentInChildren<ResetButtonView>();
            if (_gameOverView == null) _gameOverView = GetComponentInChildren<GameOverView>();
            if(CellViews == null) CellViews = new CellView[_gameController.CellSize,_gameController.CellSize];
            _resetButtonView.Action = OnClickResetButton;
        }

        private void Start()
        {
            //1次元配列を2次元配列に変換
            var cells =GetComponentsInChildren<CellView>();
            int cnt = 0;
            for (int i = 0; i < _gameController.CellSize; i++)
            {
                for (int j = 0; j < _gameController.CellSize; j++)
                {
                    cells[cnt].SetColor(Color.white);
                    cells[cnt].ClickAction = OnClickCell(j,i);
                    CellViews[j, i] = cells[cnt];
                    cnt++;
                }
            }
            _gameController.ResetCells();
        }
        public void SetCellColor(int x, int y, Color color)
        {
            CellViews[x, y].SetColor(color);
        }

        public void WriteGameOverView(string text)
        {
            _gameOverView.Write(text);
        }

        private Action OnClickCell(int x, int y)
        {
            return () => _gameController.Open(x,y);
        }

        private void OnClickResetButton()
        {
            _gameController.ResetCells();
        }
        public void Renderer()
        {
        }
    }
}