using UnityEngine;

namespace MVC.Models
{
    public class EnemyModel : ICharacterModel
    {
        public string StartTurn()
        {
            return "敵のターン！";
        }

        public Color Color { get; set; } = Color.blue;
    }
}