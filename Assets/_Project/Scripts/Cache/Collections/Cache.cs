using System.Collections.Generic;
using UnityEngine;

namespace _Project.Cache.Collections
{
    public sealed class Cache<T>
    {
        private readonly float _storageTime;
        private readonly Dictionary<string, CacheUnit<T>> _cache;

        public Cache(float storageTime)
        {
            _storageTime = storageTime;
            _cache = new Dictionary<string, CacheUnit<T>>();
        }
        
        public bool IsValid(string key)
        {
            if (_cache.TryGetValue(key, out CacheUnit<T> cacheUnit))
            {
                return IsValid(cacheUnit);
            }

            return false;
        }

        public bool TryGet(string key, out T data)
        {
            if (_cache.TryGetValue(key, out CacheUnit<T> cacheUnit))
            {
                data = cacheUnit.Member;
                return true;
            }

            data = default;
            return false;
        }
        
        public bool TryGetValid(string key, out T data)
        {
            if (_cache.TryGetValue(key, out CacheUnit<T> cacheUnit) && IsValid(cacheUnit))
            {
                data = cacheUnit.Member;
                return true;
            }

            data = default;
            return false;
        }
        
        public void Paste(string key, T data) => 
            Paste(key, data, _storageTime);

        public void Paste(string key, T data, float storageTime)
        {
            if (!_cache.TryGetValue(key, out CacheUnit<T> cacheUnit))
            {
                cacheUnit = new CacheUnit<T>
                {
                    Key = key
                };

                _cache.Add(key, cacheUnit);
            }
            
            cacheUnit.Member = data;
            cacheUnit.ExpireTime = Time.realtimeSinceStartup + storageTime;
        }

        public void Delete(string key) => 
            _cache.Remove(key);

        public void Clear() => 
            _cache.Clear();
        
        private bool IsValid(CacheUnit<T> cacheUnit)
        {
            var currentTime = Time.realtimeSinceStartup;
            var result = currentTime <= cacheUnit.ExpireTime;
            
            return result;
        }
    }
}