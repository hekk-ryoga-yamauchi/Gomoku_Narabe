namespace DefaultNamespace
{
    public class CellModel
    {
        public int X;
        public int Y;
        public bool IsOpened = false;
        public int CharaId;

        public CellModel(int x, int y)
        {
            X = x;
            Y = y;
            CharaId = -1;
        }
    }
}