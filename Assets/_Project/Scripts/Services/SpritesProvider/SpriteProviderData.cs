using System;
using UnityEngine;

namespace _Project.Services.SpritesProvider
{
    [Serializable]
    public class SpriteProviderData<TKey>
    {
        [SerializeField] private TKey key;
        [SerializeField] private Sprite sprite;
        
        public TKey Key => key;
        public Sprite Sprite => sprite;
    }
}