using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    public CellModel Cell
    {
        get { return _cell;}
        set
        {
            _cell = value;
            _image.color = value.Color;
        }
    }

    private CellModel _cell;

    [SerializeField] private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnClick()
    {
        if (Cell.IsOpened) return; //すでにそのセル画空いてたらスキップする
        if (GameModel.Instance.IsGameOver) return;
        GameController.Instance.Open(Cell.X,Cell.Y); //ViweからControllerに投げる
        _image.color = Cell.Color;
    }
}
