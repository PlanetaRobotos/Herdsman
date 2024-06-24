using _Project.Currencies.Data;
using UnityEngine;

namespace _Project.Currencies.SaveLoad
{
    public interface ISaveLoadCurrencies
    {
        void SaveCurrency(CurrencyIds id, int amount);
        int LoadCurrency(CurrencyIds id);
    }

    public class SaveLoadCurrencies : ISaveLoadCurrencies
    {
        public void SaveCurrency(CurrencyIds id, int amount)
        {
            PlayerPrefs.SetInt($"Currency_{id}", amount);
        }
        
        public int LoadCurrency(CurrencyIds id)
        {
            return PlayerPrefs.GetInt($"Currency_{id}", 0);
        }
    }
}