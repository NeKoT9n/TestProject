using Assets.Scripts.Features.Rewards;
using Assets.Scripts.Helpers;
using Assets.Scripts.Levels;
using Assets.Scripts.Settings;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Data
{

    public class SaveLoadService : ISaveLoadService, UI.Windows.IInitializable
    {
        private readonly IUserDataContainer _userDataContainer;
        private readonly JsonSaverLoader<RewardsData> _rewardDataLoader;
        private readonly JsonSaverLoader<SettingsData> _settingsDataLoader;
        private readonly JsonSaverLoader<LevelsData> _levelsDataLoader;
        private readonly JsonSaverLoader<PlayerData> _playerDataLoader;

        [Inject]
        public SaveLoadService(IUserDataContainer userDataContainer)
        {
            _userDataContainer = userDataContainer;

            _rewardDataLoader = new JsonSaverLoader<RewardsData>(Constants.REWARD_DATA_PATH);
            _settingsDataLoader = new JsonSaverLoader<SettingsData>(Constants.SETTINGS_DATA_PATH);
            _levelsDataLoader = new JsonSaverLoader<LevelsData>(Constants.LEVELS_DATA_PATH);
            _playerDataLoader = new JsonSaverLoader<PlayerData>(Constants.PLAYER_DATA_PATH);
        }

        public void Initialize()
        {
            Load();
        }

        public void Load()
        {
            LoadLevelsData();
            LoadRewardsData();
            LoadSettingsData();
            LoadPlayerData();
           
        }

        public void Save()
        {
            _settingsDataLoader.Save(_userDataContainer.SettingsData);
            _levelsDataLoader.Save(_userDataContainer.LevelsData);
            _rewardDataLoader.Save(_userDataContainer.RewardsData);
            _playerDataLoader.Save(_userDataContainer.PlayerData);

            Debug.Log("Saved");
        }


        private void LoadLevelsData()
        {
            LevelsData data;
            _levelsDataLoader.Load(out data);
            _userDataContainer.LevelsData = data;

        }

        private void LoadSettingsData()
        {
            SettingsData data;
            _settingsDataLoader.Load(out data);
            _userDataContainer.SettingsData = data;
        }

        private void LoadPlayerData()
        {
            PlayerData data;
            _playerDataLoader.Load(out data);
            _userDataContainer.PlayerData = data;
        }

        private void LoadRewardsData()
        {
            RewardsData data;
            _rewardDataLoader.Load(out data);
            _userDataContainer.RewardsData = data;
        }
    }
}