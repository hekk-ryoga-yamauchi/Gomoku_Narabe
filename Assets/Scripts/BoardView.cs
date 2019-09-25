using UnityEngine;
using UnityEngine.UI;

public class BoardView : MonoBehaviour
{
    public Text GameOverText;
    public void WriteGameOver()
    {
        if (GameModel.Instance.CurrentTurnCharaId == 0)
        {
            GameOverText.text = "GameOver!! You Win!!";
        }
        else
        {
            GameOverText.text = "GameOver!! You lose..";
        }
    }

    public void WriteEmpty()
    {
        GameOverText.text = "";
    }
}
