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
            if (Character is Player)
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

    public ICharactor Character;

    public CellModel(int x, int y)
    {
        IsOpened = false;
        X = x;
        Y = y;
        Character = new Dummy(); //誰の物でもないセルは現状ダミーにしてるけど何にしたら良いのか
        SetColor(Color.white);
    }

    private void SetColor(Color color)
    {
        Color = color;
    }
}