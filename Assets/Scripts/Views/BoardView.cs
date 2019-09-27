using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class BoardView : MonoBehaviour
    {
        [SerializeField] private Text GameOverText;

        public void WriteGameOver(bool wonPlayer)
        {
            GameOverText.text = wonPlayer ? "GameOver!! You Win!!" : "GameOver!! You lose..";
        }

        public void WriteEmpty()
        {
            GameOverText.text = "";
        }
    }
}
