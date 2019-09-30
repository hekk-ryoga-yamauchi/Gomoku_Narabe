using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.Views
{
    public class ChangeTurnTextView : MonoBehaviour
    {
        [SerializeField] private Animation _animation;
        [SerializeField] private Text _text;

        public IEnumerator PlayAnimation(string text)
        {
            _text.text = text;
            _animation.Play();
            while (_animation.isPlaying)
            {
                yield return null;
            }
        }
    }
}