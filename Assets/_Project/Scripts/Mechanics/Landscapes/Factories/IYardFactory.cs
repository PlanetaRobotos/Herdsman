using _Project.Mechanics.Landscapes.Configs;
using Cysharp.Threading.Tasks;

namespace _Project.Mechanics.Landscapes.Factories
{
    public interface IYardFactory
    {
        UniTask<Yard> Load(string key);
        IYard Instantiate(Yard template, YardConfig yardConfig);
    }
}