using UnityEngine;

public class GameView  : MonoBehaviour
{
    [SerializeField] private CellsView CellsView;
    [SerializeField] private BoardView BoardView;
    private void Awake()
    {
        GameController.Instance.GameView = this;
    }

    private void Start()
    {
        if (CellsView == null) CellsView = GetComponentInChildren<CellsView>();
        if (BoardView == null) BoardView = GetComponentInChildren<BoardView>();
        GameController.Instance.ResetCells();
    }

    public void ClearCells()
    {
        CellsView.UpdateView();
    }

    public void GameOver()
    {
        BoardView.WriteGameOver();
    }

    public void WriteToBoardEmpty()
    {
        BoardView.WriteEmpty();
    }
}