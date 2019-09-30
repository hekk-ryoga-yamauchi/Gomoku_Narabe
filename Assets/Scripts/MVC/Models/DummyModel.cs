using UnityEngine;

namespace MVC.Models
{
    public class DummyModel : ICharacterModel
    {
        public string StartTurn()
        {
            return "バグ";
        }

        public Color Color { get; set; } = Color.black;
    }
}