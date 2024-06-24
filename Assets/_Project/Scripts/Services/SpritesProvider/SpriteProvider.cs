using System;
using System.Linq;
using UnityEngine;

namespace _Project.Services.SpritesProvider
{
    public class SpriteProvider<TKey> : ScriptableObject
    {
        [SerializeField] private SpriteProviderData<TKey>[] data = Array.Empty<SpriteProviderData<TKey>>();
        
        public bool IsContainsSprite(TKey key) => 
            data.Any(d => d.Key.Equals(key));

        public virtual Sprite GetSprite(TKey key) => 
            (from data in data where data.Key.Equals(key) select data.Sprite).FirstOrDefault();
    }
}