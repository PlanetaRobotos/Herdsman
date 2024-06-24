using UnityEngine;

namespace _Project.Mechanics.Entities.Configs
{
    [CreateAssetMenu(fileName = "PlayerEntityConfig", menuName = "Entities/PlayerEntityConfig")]
    public class PlayerEntityConfig: ScriptableObject
    {
        [field: SerializeField] public float PlayerRotationSpeed { get; private set; }
        [field: SerializeField] public float PlayerMoveSpeed { get; private set; }
    }
}