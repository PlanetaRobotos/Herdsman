using _Project.ClientData.Leaderboards;
using _Project.Services.AvatarService;
using _Project.Services.AvatarService.Core;
using MVVM;
using MVVM.Collections;
using UnityEngine;

namespace _Project.Windows.Loading.Providers
{
    public class LeaderboardUserViewModel : ModelView<ILeaderboardUserData>
    {
        public ReactiveProperty<int> RatingPosition { get; } = new(-1);
        public ReactiveProperty<int> RatingScore { get; } = new(-1);
        public ReactiveProperty<string> PlayerName { get; } = new();
        public ReactiveProperty<bool> IsVip { get; } = new();
        public ReactiveProperty<bool> IsPlayer { get; } = new();
        public ReactiveProperty<PlayerAvatarModel> AvatarModel { get; } = new();
        public ILeaderboardUserData GameUser { get; private set; }

        public override void SetModel(ILeaderboardUserData model)
        {
            GameUser = model;
            RatingPosition.Value = model.RatingPosition;
            Debug.Log($"RatingPosition: {model.RatingPosition}");
            RatingScore.Value = model.RatingScore;
            PlayerName.Value = model.Name;
            IsPlayer.Value = model.IsPlayer;
            AvatarModel.Value = model.GetIconModel();
            IsVip.Value = model.IsVip;
        }
    }
}