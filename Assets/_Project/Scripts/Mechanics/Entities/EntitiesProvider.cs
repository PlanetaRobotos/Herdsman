using System.Collections.Generic;
using _Project.Currencies.Abstract;
using _Project.Currencies.Data;
using _Project.Mechanics.Entities.Abstract;
using _Project.Mechanics.Entities.AI.AIEntities;
using _Project.Mechanics.Entities.Impl;
using CollectionsPooling;

namespace _Project.Mechanics.Entities
{
    public class EntitiesProvider
    {
        [Inject] private ICurrencyProvider CurrencyProvider { get; }
        [Inject] private ICollectionsPoolService CollectionsPoolService { get; }

        public PlayerEntity PlayerEntity { get; set; }
        public List<AIBase> Animals { get; }

        public EntitiesProvider()
        {
            Animals = CollectionsPoolService.GetList<AIBase>();
        }

        public void AddScore(AIBase entity)
        {
            CurrencyProvider.AddCurrency(CurrencyIds.Coins, entity.Cost);
        }
    }
}