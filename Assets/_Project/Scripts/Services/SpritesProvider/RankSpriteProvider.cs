using UnityEngine;

namespace _Project.Services.SpritesProvider
{
    [CreateAssetMenu(fileName = "RankSpriteProvider", menuName = "Utils/SpriteProviders/RankSpriteProvider")]
    public class RankSpriteProvider : SpriteProviderIntKey
    {
        [field: SerializeField] public Sprite DefaultBackground { get; private set; }
    }
}