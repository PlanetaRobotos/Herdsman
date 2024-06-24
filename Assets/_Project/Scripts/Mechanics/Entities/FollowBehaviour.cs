using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Mechanics.Entities.Abstract;
using _Project.Mechanics.Entities.AI.AIEntities;
using _Project.Mechanics.Entities.Configs;
using _Project.Mechanics.Entities.Formations;
using _Project.Mechanics.Entities.Models;
using _Project.Mechanics.Entities.Registrators;
using CollectionsPooling;
using UnityEngine;

namespace _Project.Mechanics.Entities
{
    public class FollowBehaviour : IDisposable
    {
        [Inject] private EntitiesProvider EntitiesProvider { get; }
        [Inject] private EntitiesConfig EntitiesConfig { get; }
        [Inject] private ICollectionsPoolService CollectionsPoolService { get; }

        private List<AIBase> _entities;
        private Formation _grid;

        public void Initialize()
        {
            _grid = EntitiesConfig.FollowType switch
            {
                FollowType.Line => new LineFormation(EntitiesConfig.LineFormation, EntitiesConfig.MaxFollowAmount),
                FollowType.Circle => new CircleFormation(EntitiesConfig.CircleFormation,
                    EntitiesConfig.MaxFollowAmount),
                _ => _grid
            };
            
            _entities = CollectionsPoolService.GetList<AIBase>();
        }

        public void AddToGroup(AIBase entity)
        {
            _entities.Add(entity);
        }

        public bool CanBeAddedToGroup(AIBase entity) =>
            !_entities.Contains(entity) && _entities.Count < EntitiesConfig.MaxFollowAmount;

        public void RemoveFromGroup(AIBase animal)
        {
            if (_entities.Contains(animal))
            {
                _entities.Remove(animal);
            }
        }

        public void UpdateAnimalPositions()
        {
            List<Vector2> gridPositions =
                _grid.CalculatePositions(EntitiesProvider.PlayerEntity.FollowParent.position,
                    _entities.Select(x => x.transform).ToList());
            EntitiesProvider.PlayerEntity.SetFollowPositions(gridPositions);
        }

        public void Dispose()
        {
            CollectionsPoolService.Release(_entities);
        }
    }
}