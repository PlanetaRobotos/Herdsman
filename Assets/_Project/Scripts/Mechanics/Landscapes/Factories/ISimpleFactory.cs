using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Mechanics.Landscapes.Factories
{
    public interface ISimpleFactory<RetType, in TConfig>
    {
        UniTask<RetType> Load(string key);
        RetType Instantiate(RetType template, TConfig landscapeConfig, Transform parent);
    }
}