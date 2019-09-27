using System;
using UnityEngine;

namespace Views
{
    public class ResetButtonView : MonoBehaviour
    {
        public Action Clicked { get; set; }

        public void OnClick()
        {
            Clicked?.Invoke();
        }
    }
}
