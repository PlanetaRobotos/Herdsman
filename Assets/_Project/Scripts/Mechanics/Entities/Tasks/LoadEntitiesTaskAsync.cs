using System.Collections.Generic;
using _Project.Mechanics.Entities.Abstract;
using _Project.Mechanics.Entities.AI.AIEntities;
using _Project.Mechanics.Entities.Configs;
using _Project.Mechanics.Entities.Impl;
using _Project.Mechanics.Entities.Spawners;
using _Project.Mechanics.Landscapes.Providers;
using _Project.Scripts.Infrastructure.ApplicationObservers.Runtime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Mechanics.Entities.Tasks
{
    public class LoadEntitiesTaskAsync : AsyncTask
    {
        [Inject] private IEntityFactory _entityFactory { get; }
        [Inject] private EntitiesConfig _entitiesConfig { get; }
        [Inject] private EntitiesProvider EntitiesProvider { get; }
        [Inject] private IEntitiesSpawner EntitiesSpawner { get; }
        [Inject] private LandscapeProvider LandscapeProvider { get; }
        [Inject] private IUpdater Updater { get; }

        protected override async UniTask DoAsync()
        {
            var playerTemplate = await _entityFactory.Load<PlayerEntity>();
            var player = (PlayerEntity)_entityFactory.Instantiate(playerTemplate, "Player");
            EntitiesProvider.PlayerEntity = player;
            EntitiesProvider.PlayerEntity.Initialize(Updater,
                player.Config.PlayerRotationSpeed, player.Config.PlayerMoveSpeed);
            EntitiesProvider.PlayerEntity.SpawnFollowPoints(_entitiesConfig.MaxFollowAmount);

            var animalTemplate = await _entityFactory.Load<SimpleAI>();
            EntitiesSpawner.SpawnInInterval(new List<BaseEntity> { animalTemplate },
                LandscapeProvider.CurrentLandscape.GetComponent<Collider2D>(), _entitiesConfig.SpawnDelayInterval,
                _entitiesConfig.MaxAnimalsAmount, new GameObject("Animals").transform).Forget();
        }
    }
}