using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardView : MonoBehaviour
{
    public Text GameOverText;
    public void GameOver()
    {
        if (GameController.Instance.CurrentTurnCharaId == 0)
        {
            GameOverText.text += "GameOver!! You Win!!";
        }
        else
        {
            GameOverText.text += "GameOver!! You lose..";
        }
    }
}
