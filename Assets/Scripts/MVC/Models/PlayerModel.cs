using System.Collections;
using UnityEngine;

namespace MVC.Models
{
    public class PlayerModel : ICharacterModel
    {
        public string StartTurn()
        {
            return "あなたのターン！";
        }

        public Color Color { get; set; } = Color.red;
    }
}