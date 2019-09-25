using UnityEngine;
using UnityEngine.UI;

public class CellModel
{
    public readonly int X;
    public readonly int Y;
    public Color Color;

    public bool IsOpened
    {
        get => _isOpened;
        set
        {
            _isOpened = value;
            if (CharaId == 0)
            {
                SetColor(Color.red);
            }
            else
            {
                SetColor(Color.blue);
            }
        }
    }

    private bool _isOpened;

    public int CharaId;

    public CellModel(int x, int y)
    {
        IsOpened = false;
        X = x;
        Y = y;
        CharaId = -1;
        SetColor(Color.white);
    }

    private void SetColor(Color color)
    {
        Color = color;
    }
}