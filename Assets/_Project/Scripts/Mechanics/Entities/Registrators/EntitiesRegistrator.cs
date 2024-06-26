﻿using _Project.Mechanics.Entities.Abstract;
using _Project.Mechanics.Entities.Configs;
using _Project.Mechanics.Entities.Factories;
using _Project.Mechanics.Entities.Spawners;
using ServiceLocator.Core;
using UnityEngine;

namespace _Project.Mechanics.Entities.Registrators
{
    public class EntitiesRegistrator: BaseMonoServicesRegistrator
    {
        [SerializeField] private EntitiesConfig _entitiesConfig;
        
        public override void Register()
        {
            Locator.Register(_entitiesConfig);
            var entityFactory = new EntityFactory(_entitiesConfig);
            Locator.Register<IEntityFactory>(entityFactory);
            Locator.Register(new EntitiesProvider());
            Locator.Register<IEntitiesSpawner>(new EntitiesSpawner(_entitiesConfig, entityFactory));
            Locator.Register(new FollowBehaviour());
        }
    }
}