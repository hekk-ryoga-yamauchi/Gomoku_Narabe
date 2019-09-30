using System;
using UnityEngine;

namespace MVC.Views
{
    public class ResetButtonView : MonoBehaviour
    {
        public Action Action;

        public void OnClick()
        {
            Action?.Invoke();
        }
    }
}