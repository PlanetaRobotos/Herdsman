using System;
using UnityEngine;

namespace _Project.Services.AvatarService.Core
{
    public interface IAvatarService
    {
        void LoadSpriteProviders();
        Sprite GetFlag(string countryId);
        void GetAvatar(string avatarId, Action<Sprite> onSpriteLoad);
    }
}