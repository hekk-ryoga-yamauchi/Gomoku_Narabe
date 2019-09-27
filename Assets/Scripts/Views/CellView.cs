using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        private CellViewModel _cellViewModel;

        public int X => _cellViewModel.X;
        public int Y => _cellViewModel.Y;
        public Action<int, int> Clicked { get; set; }

        public void OnClick()
        {
            Clicked?.Invoke(_cellViewModel.X, _cellViewModel.Y);
        }

        public void ResetViewModel(CellViewModel cellViewModel)
        {
            _cellViewModel = cellViewModel;
            SetColor(Color.white);
        }

        public void SetColor(Color color)
        {
            _image.color = color;
        }

        private void Awake()
        {
            _image = GetComponent<Image>();
        }
    }
}
