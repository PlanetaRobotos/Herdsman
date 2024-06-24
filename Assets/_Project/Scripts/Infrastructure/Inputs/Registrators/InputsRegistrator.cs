using _Project.Infrastructure.Inputs.Abstract;
using ServiceLocator.Core;
using UnityEditor.Experimental.RestService;

namespace _Project.Infrastructure.Inputs.Registrators
{
    public class InputsRegistrator: BaseMonoServicesRegistrator
    {
        public override void Register()
        {
            Locator.Register<IInputObserver>(new InputObserver());
        }
    }
}