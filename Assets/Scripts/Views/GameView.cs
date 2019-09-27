using Presenters;
using UnityEngine;

namespace Views
{
    public interface IGameView
    {
        void ClearCells(CellViewModel[] cellViewModels);
        void GameOver(bool wonPlayer);
        void WriteToBoardEmpty();
        void UpdateCellColor(int x, int y, Color color);
    }

    public class GameView  : MonoBehaviour, IGameView
    {
        [SerializeField] private CellsView _cellsView = default;
        [SerializeField] private BoardView _boardView = default;
        [SerializeField] private ResetButtonView _resetButtonView = default;
        private GamePresenter _gamePresenter;

        public void ClearCells(CellViewModel[] cellViewModels)
        {
            _cellsView.ResetCells(cellViewModels);
        }

        public void GameOver(bool wonPlayer)
        {
            _boardView.WriteGameOver(wonPlayer);
        }

        public void WriteToBoardEmpty()
        {
            _boardView.WriteEmpty();
        }

        public void UpdateCellColor(int x, int y, Color color)
        {
            var cellView = _cellsView.GetCellView(x, y);
            if (cellView != null)
            {
                cellView.SetColor(color);
            }
        }

        private void Awake()
        {
            _gamePresenter = new GamePresenter(this);
        }

        private void Start()
        {
            _gamePresenter.ResetCells();

            _resetButtonView.Clicked = OnClickResetButton;
            foreach (var cellView in _cellsView.GetCellViews())
            {
                cellView.Clicked = OnClickCell;
            }
        }

        private void OnClickCell(int x, int y)
        {
            _gamePresenter.Open(x, y);
        }

        private void OnClickResetButton()
        {
            _gamePresenter.ResetCells();
        }
    }
}
