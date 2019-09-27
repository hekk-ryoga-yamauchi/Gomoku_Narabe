namespace Views
{
    public readonly struct CellViewModel
    {
        public readonly int X;
        public readonly int Y;

        public CellViewModel(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
