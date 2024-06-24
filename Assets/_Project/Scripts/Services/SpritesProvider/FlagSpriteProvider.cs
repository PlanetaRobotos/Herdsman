using UnityEngine;

namespace _Project.Services.SpritesProvider
{
    [CreateAssetMenu(fileName = "FlagSpriteProvider", menuName = "Utils/SpriteProviders/FlagSpriteProvider")]
    public class FlagSpriteProvider : SpriteProviderStringKey
    {
        [field: SerializeField] public Sprite DefaultFlag { get; private set; }
    }
}