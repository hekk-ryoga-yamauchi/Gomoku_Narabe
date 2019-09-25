public class Player : IPlayer//interfaceに切ったほうがいい
    {
        public int Id = 0; //なくてもいい getter
        public void StartTurn() 
        {
            
        }

        public void ClickCell()
        {
        }
    }

    public interface IPlayer
    {
        void StartTurn();

        void ClickCell();
    }