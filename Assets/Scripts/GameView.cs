using UnityEngine;

public class GameView  : MonoBehaviour
{
    public CellsView CellsView;
    public BoardView BoardView;
    private void Awake()
    {
        GameController.Instance.GameView = this;
    }

    private void Start()
    {
        if (CellsView == null) GetComponentInChildren<CellsView>();
        if (BoardView == null) GetComponentInChildren<BoardView>();
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