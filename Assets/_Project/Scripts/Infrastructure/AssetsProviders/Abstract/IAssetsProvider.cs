using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace _Project.Infrastructure.AssetsProviders.Abstract
{
    public interface IAssetsProvider
    {
        UniTask<T> LoadAssetAsync<T>(AssetReference reference);
        UniTask<T> LoadAssetAsync<T>(string address);
        void CleanUp();
    }
}