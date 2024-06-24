using System;
using _Project.Configs;
using _Project.Services.AvatarService.Core;
using _Project.Services.SpritesProvider;
using UnityEngine;

namespace _Project.Services.AvatarService
{
    public class AvatarService : IAvatarService
    {
        private AvatarSpriteProvider _avatarSpriteProvider;
        private FlagSpriteProvider _flagSpriteProvider;

        [Inject] private ConfigsController ConfigsController { get; }

        public void LoadSpriteProviders()
        {
            _avatarSpriteProvider = ConfigsController.Resolve<AvatarSpriteProvider>();
            _flagSpriteProvider = ConfigsController.Resolve<FlagSpriteProvider>();
        }

        public Sprite GetFlag(string countryId)
        {
            return _flagSpriteProvider.IsContainsSprite(countryId)
                ? _flagSpriteProvider.GetSprite(countryId)
                : _flagSpriteProvider.DefaultFlag;
        }

        public void GetAvatar(string avatarId, Action<Sprite> onSpriteLoad)
        {
            Sprite avatar = _avatarSpriteProvider.IsContainsSprite(avatarId)
                ? _avatarSpriteProvider.GetSprite(avatarId)
                : _avatarSpriteProvider.DefaultAvatar;

            onSpriteLoad?.Invoke(avatar);
        }
    }
}