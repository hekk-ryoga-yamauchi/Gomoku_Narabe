using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    public CellModel Cell;
    [SerializeField] private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void OnClick()
    {
        if (Cell.IsOpened) return;
        Open();
        GameController.Instance.CheckBoard();
        if (GameController.Instance.OnGameOver)
        {
            GameObject.Find("board").GetComponent<BoardView>().GameOver();
        }
        if (GameController.Instance.CurrentTurnCharaId == 0)
        {
            _image.color = Color.red;
        }
        else
        {
            _image.color = Color.blue;
        }
        GameController.Instance.ChangeTurn();
    }

    public void Open()
    {
        Cell.CharaId = GameController.Instance.CurrentTurnCharaId;
        Cell.IsOpened = true;
    }
}
