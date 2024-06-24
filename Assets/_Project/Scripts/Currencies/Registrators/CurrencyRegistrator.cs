using _Project.Currencies.Abstract;
using _Project.Currencies.Providers;
using _Project.Currencies.SaveLoad;
using ServiceLocator.Core;

namespace _Project.Currencies.Registrators
{
    public class CurrencyRegistrator: BaseMonoServicesRegistrator
    {
        public override void Register()
        {
            Locator.Register<ICurrencyProvider>(new CurrencyProvider(new SaveLoadCurrencies()));
        }
    }
}