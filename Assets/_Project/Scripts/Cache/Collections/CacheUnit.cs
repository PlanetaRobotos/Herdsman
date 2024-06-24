namespace _Project.Cache.Collections
{
    public sealed class CacheUnit<T>
    {
        public string Key { get; set; }
        public float ExpireTime { get; set; }
        public T Member { get; set; }
    }
}