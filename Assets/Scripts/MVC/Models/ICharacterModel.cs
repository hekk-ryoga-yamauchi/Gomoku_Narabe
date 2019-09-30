using UnityEngine;

namespace MVC.Models
{
    public interface ICharacterModel
    {
        string StartTurn();
        Color Color { get; set; }
    }
}