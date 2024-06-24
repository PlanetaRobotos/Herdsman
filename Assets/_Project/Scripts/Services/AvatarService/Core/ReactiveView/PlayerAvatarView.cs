using System.Diagnostics.CodeAnalysis;
using _Project.Configs;
using _Project.Services.SpritesProvider;
using MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Services.AvatarService.Core.ReactiveView
{
    public class PlayerAvatarView : View<PlayerAvatarModel>
    {
        [SerializeField] private Image _avatar;
        [SerializeField] private Image _frame;
        [SerializeField] private Image _flag;
        [SerializeField] private Image _rankIcon;

        private RankSpriteProvider _spriteProvider;

        [Inject] private readonly IAvatarService _avatarService;
        [Inject] private readonly ConfigsController _configsController;

        private void Awake()
        {
            _spriteProvider = _configsController.Resolve<RankSpriteProvider>();
        }

        protected override void UpdateView(PlayerAvatarModel value)
        {
            if (value == null)
            {
                ClearImages();
                return;
            }

            if (_avatar) SetPlayerIcon(value.AvatarId, _avatar);
            if (_frame) SetFrameColor(value);
            
            if (_flag) SetPlayerFlag(value.Country, _flag);
            if (_rankIcon) SetRankIcon(value.Rank, _rankIcon);
        }

        private void SetFrameColor(PlayerAvatarModel value)
        {
            if (ColorUtility.TryParseHtmlString(value.Color, out Color color))
                _frame.color = color;
            else
                Debug.LogWarning($"Invalid hex color string {value.Color}");
        }

        private void SetRankIcon(int rank, [NotNull] Image root)
        {
            root.sprite = _spriteProvider.IsContainsSprite(rank)
                ? _spriteProvider.GetSprite(rank)
                : _spriteProvider.DefaultBackground;
        }

        private void ClearImages()
        {
            if (_avatar)
                _avatar.sprite = null;
            if (_flag)
                _flag.sprite = null;
            if (_frame)
                _frame.sprite = null;
        }

        private void SetPlayerIcon(string avatarId, [NotNull] Image root) =>
            _avatarService.GetAvatar(avatarId, x => { root.sprite = x; });

        private void SetPlayerFlag(string countryId, [NotNull] Image root) =>
            root.sprite = _avatarService.GetFlag(countryId);
    }
}