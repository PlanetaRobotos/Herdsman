using System;
using UnityEngine;

namespace _Project.Services.SpritesProvider
{
    [CreateAssetMenu(fileName = "SpritesContainerByName", menuName = "Utils/SpritesContainerByName")]
    public class SpritesContainerByName : ScriptableObject
    {
        [Serializable]
        private struct SpriteData
        {
            [SerializeField] private string _name;
            [SerializeField] private Sprite _sprite;

            public string Name => _name;
            public Sprite Sprite => _sprite;
        }

        [SerializeField] private SpriteData[] _spriteCollection;


        public Sprite GetSpriteById(string id)
        {
            for (int i = 0; i < _spriteCollection.Length; i++)
            {
                if (_spriteCollection[i].Name == id)
                    return _spriteCollection[i].Sprite;
            }

            return null;
        }
    }
}