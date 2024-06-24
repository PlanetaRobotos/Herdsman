using _Project.ClientData.Leaderboards;
using _Project.Services.AvatarService.Core;

namespace _Project.Services.AvatarService
{
    public static class PlayerIconModelExtensions
    {
        public static PlayerAvatarModel GetIconModel(this ILeaderboardUserData from) => new(from.Avatar.ToString(), from.Country, from.RatingPosition, from.AvatarColor);
    }
}