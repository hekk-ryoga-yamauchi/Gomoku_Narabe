using UnityEngine;

namespace MVC.Models
{
    public class CellModel
    {
        public readonly int X; //範囲外の時、プロパティなら弾ける

        public readonly int Y;

//        private Color _color;
        private ICharacterModel CharacterModel;

        public void SetCharacterModel(ICharacterModel characterModel)
        {
            CharacterModel = characterModel;
        }

        public ICharacterModel GetCharacterModel()
        {
            return CharacterModel;
        }


        public CellModel(int x, int y)
        {
            X = x;
            Y = y;
            CharacterModel = new DummyModel();
        }

        public bool IsOpened()
        {
            if (CharacterModel is PlayerModel || CharacterModel is EnemyModel)
            {
                return true;
            }

            return false;
        }
    }
}