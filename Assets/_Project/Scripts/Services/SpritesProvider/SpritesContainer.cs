using System;
using UnityEngine;

namespace _Project.Services.SpritesProvider
{
    [Serializable]
    public struct SpriteCollection
    {
        public string spriteId;
        public Sprite sprite;
    }

    [CreateAssetMenu(fileName = "SpritesContainer", menuName = "Utils/SpritesContainer")]
    public class SpritesContainer : ScriptableObject
    {
        [SerializeField] private SpriteCollection[] _collection;

        public SpriteCollection[] GetAllItems() => _collection;

        public Sprite GetSpriteById(string id)
        {
            for (int i = 0; i < _collection.Length; i++)
            {
                if (_collection[i].spriteId == id)
                    return _collection[i].sprite;
            }
            return _collection[0].sprite;
        }
    }
}