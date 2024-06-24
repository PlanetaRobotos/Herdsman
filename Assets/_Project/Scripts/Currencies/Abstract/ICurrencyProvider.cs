using System;
using _Project.Currencies.Data;

namespace _Project.Currencies.Abstract
{
    public interface ICurrencyProvider
    {
        event Action<CurrencyIds, int> OnCurrencyChangedEvent;
        void SetCurrency(CurrencyIds id, int value);
        InGameCurrency GetCurrency(CurrencyIds id);
        void AddCurrency(CurrencyIds id, int value);
    }
}