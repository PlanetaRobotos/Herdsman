using UnityEngine;

namespace _Project.Services.SpritesProvider
{
    [CreateAssetMenu(fileName = "AvatarSpriteProvider", menuName = "Utils/SpriteProviders/AvatarSpriteProvider")]
    public class AvatarSpriteProvider : SpriteProviderStringKey
    {
        [field: SerializeField] public Sprite DefaultAvatar { get; private set; }
    }
}