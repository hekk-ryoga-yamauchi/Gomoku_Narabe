using UnityEngine;
using UnityEngine.UI;

namespace MVC.Views
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private Text GameOverText;
        private string _text = "";

        private void Start()
        {
            GameOverText = GetComponent<Text>();
        }

        public void Write(string text)
        {
            _text = text;
            Render();
        }

        public void Render()
        {
            GameOverText.text = _text;
        }
    }
}