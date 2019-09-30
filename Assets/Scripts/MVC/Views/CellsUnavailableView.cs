using UnityEngine;
using UnityEngine.UI;

namespace MVC.Views
{
    public class CellsUnavailableView : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void Enable()
        {
            _image.raycastTarget = false;
        }

        public void Unavailable()
        {
            _image.raycastTarget = true;
        }
    }
}