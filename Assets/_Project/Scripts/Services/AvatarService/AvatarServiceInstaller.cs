using _Project.Services.AvatarService.Core;
using ServiceLocator.Core;

namespace _Project.Services.AvatarService
{
    public class AvatarServiceInstaller : BaseMonoServicesRegistrator
    {
        public override void Register()
        {
            Locator.Register<IAvatarService>(new AvatarService());
        }
    }
}