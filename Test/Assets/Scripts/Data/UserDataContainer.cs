using Assets.Scripts.Features.Rewards;
using Assets.Scripts.Levels;
using Assets.Scripts.Settings;

namespace Assets.Scripts.Data
{
    public interface IUserDataContainer
    {
        public SettingsData SettingsData { get; set; }
        public RewardsData RewardsData { get; set; }
        public LevelsData LevelsData { get; set; }
        public PlayerData PlayerData { get; set; }

    }

    public class UserDataContainer : IUserDataContainer
    {
        public SettingsData SettingsData { get; set; }
        public RewardsData RewardsData { get; set; }
        public LevelsData LevelsData { get; set; }

        public PlayerData PlayerData { get; set; }

    }
}