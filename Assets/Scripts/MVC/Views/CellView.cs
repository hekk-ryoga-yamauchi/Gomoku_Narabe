using System;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.Views
{
    public class CellView : MonoBehaviour
    {
        public Action ClickAction;
        [SerializeField] private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void OnClick()
        {
            ClickAction?.Invoke();
        }

        public void SetColor(Color color)
        {
            _image.color = color;
        }
    }
}