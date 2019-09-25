using UnityEngine;
public class CellModel
{
    public readonly int X; //範囲外の時、プロパティなら弾ける
    public readonly int Y;
    private Color _color;

    public bool IsOpened
    {
        get => _isOpened;
        set
        {
            _isOpened = value;
            ChangeColor();
        }
    }

    private void ChangeColor()
    {
        if (Character is Player)
        {
            SetColor(Color.red);
        }
        else
        {
            SetColor(Color.blue);
        }
    }

    private bool _isOpened;

    public ICharactor Character;

    public CellModel(int x, int y)
    {
        IsOpened = false;
        X = x;
        Y = y;
        Character = new Dummy();
        SetColor(Color.white);
    }

    private void SetColor(Color color)
    {
        _color = color;
    }

    public Color GetColor()
    {
        return _color;
    }
}