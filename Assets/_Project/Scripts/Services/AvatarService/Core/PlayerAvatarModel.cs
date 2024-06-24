namespace _Project.Services.AvatarService.Core
{
    public class PlayerAvatarModel
    {
        public string AvatarId { get; private set; }
        public string Country { get; private set; }
        public int Rank { get; private set; }
        public string Color { get; private set; }

        public PlayerAvatarModel(string avatarId, string country, int rank, string color)
        {
            AvatarId = avatarId;
            Country = country;
            Rank = rank;
            Color = color;
        }

        public void UpdateModel(string avatarId, string country, int rank, string color)
        {
            AvatarId = avatarId;
            Country = country;
            Rank = rank;
            Color = color;
        }
    }
}