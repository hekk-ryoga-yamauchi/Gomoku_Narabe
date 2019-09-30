using System;
using System.Collections;
using MVC.Controllers;
using UnityEngine;

namespace MVC.Views
{
    public interface IGameView
    {
        void SetCellColor(int x, int y, Color color);
        void WriteGameOverView(string text);
        void StartTurn(string text);
    }

    [RequireComponent(typeof(GameView))]
    public class GameView : MonoBehaviour, IGameView
    {
        [SerializeField] private GameOverView _gameOverView = default;
        [SerializeField] private ResetButtonView _resetButtonView;
        [SerializeField] private ChangeTurnTextView _changeTurnTextView;
        [SerializeField] private CellsUnavailableView _cellsUnavailableView;
        private CellView[,] CellViews;
        private GameController _gameController;


        private void Awake()
        {
            _gameController = new GameController(this);
            CellViews = new CellView[_gameController.CellSize, _gameController.CellSize];
            _resetButtonView.Action = OnClickResetButton;
        }

        private void Start()
        {
            //1次元配列を2次元配列に変換
            var cells = GetComponentsInChildren<CellView>();
            int cnt = 0;
            for (int i = 0; i < _gameController.CellSize; i++)
            {
                for (int j = 0; j < _gameController.CellSize; j++)
                {
                    cells[cnt].SetColor(Color.white);
                    cells[cnt].ClickAction = OnClickCell(j, i);
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
            return () => _gameController.Open(x, y);
        }

        private void OnClickResetButton()
        {
            _gameController.ResetCells();
        }

        public void StartTurn(string text)
        {
            StartCoroutine(StartTurnAnimation(text));
        }

        private IEnumerator StartTurnAnimation(string text)
        {
            CellsUnavailable();
            yield return StartCoroutine(_changeTurnTextView.PlayAnimation(text));
            CellsEnable();
        }

        public void CellsUnavailable()
        {
            _cellsUnavailableView.Unavailable();
        }

        public void CellsEnable()
        {
            _cellsUnavailableView.Enable();
        }
    }
}