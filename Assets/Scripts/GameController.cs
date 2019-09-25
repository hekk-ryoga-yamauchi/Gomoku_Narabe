public class GameController //全modelを管理するクラスを作ってもいいかも
{
    public static GameController Instance { get;} = new GameController(); //シングルトンとしてはreadonlyかgetだけのプロパティにしておく必要がある、コンストラクタをprivateにするか
    public GameView GameView;
    
    public void Open(int x, int y)
    {
        GameModel.Instance.Open(x,y);
        if (GameModel.Instance.IsGameOver)
        {
            GameView.GameOver();
        }
    }

    public void ResetCells()
    {
        GameModel.Instance.SetCurrentCharacter(GameModel.Instance.Player);
        GameModel.Instance.ResetCells();
        GameView.ClearCells();
        GameView.WriteToBoardEmpty();
    }
}
