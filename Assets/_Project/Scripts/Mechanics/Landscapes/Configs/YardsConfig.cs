using System;
using UnityEngine;

namespace _Project.Mechanics.Landscapes.Configs
{
    [CreateAssetMenu(fileName = "YardsConfig", menuName = "Configs/YardsConfig")]
    public class YardsConfig : ScriptableObject
    {
        [field: SerializeField] public string[] AssetReferences { get; private set; }
        [field: SerializeField] public YardConfig[] Yards { get; private set; }
    }
    
    [Serializable]
    public class YardConfig
    {
        [field: SerializeField] public Vector2 SpawnPosition { get; private set; }
        [field: SerializeField] public Vector2 Scale { get; private set; }
    }
}