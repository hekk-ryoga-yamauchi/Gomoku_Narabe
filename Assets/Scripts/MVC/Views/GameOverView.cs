using UnityEngine;
using UnityEngine.UI;

namespace MVC.Views
{
    public class GameOverView : MonoBehaviour, IView
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
            Renderer();
        }
        public void Renderer()
        {
            GameOverText.text = _text;
        }
    }
}