using UnityEngine;
using UnityEngine.UI;

public class BoardView : MonoBehaviour
{
    [SerializeField] private Text GameOverText;
    public void WriteGameOver()
    {
        if (GameModel.Instance.GetCurrentCharacter() is Player)
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
