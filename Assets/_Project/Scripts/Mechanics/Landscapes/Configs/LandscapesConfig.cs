using System;
using UnityEngine;

namespace _Project.Mechanics.Landscapes.Configs
{
    [CreateAssetMenu(fileName = "LandscapeConfig", menuName = "Configs/LandscapeConfig")]
    public class LandscapesConfig : ScriptableObject
    {
        [field: SerializeField] public string[] AssetReferences { get; private set; }
        [field: SerializeField] public LandscapeConfig[] Landscapes { get; private set; }
    }

    [Serializable]
    public class LandscapeConfig
    {
        [field: SerializeField] public Vector2 SpawnPosition { get; private set; }
        [field: SerializeField] public Vector2 Scale { get; private set; }
    }
}